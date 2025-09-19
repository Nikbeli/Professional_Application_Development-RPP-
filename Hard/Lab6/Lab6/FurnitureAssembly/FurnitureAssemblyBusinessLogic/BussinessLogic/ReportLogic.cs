using FurnitureAssemblyBusinessLogic.OfficePackage;
using FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels;
using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.BussinessLogic
{
    // Реализация бизнес-логики отчётов
    public class ReportLogic : IReportLogic
    {
        private readonly IFurnitureStorage _furnitureStorage;

        private readonly IOrderStorage _orderStorage;

        private readonly IShopStorage _shopStorage;

        private readonly AbstractSaveToExcel _saveToExcel;

        private readonly AbstractSaveToWord _saveToWord;

        private readonly AbstractSaveToPdf _saveToPdf;

        // Инициализируем поля класса через контейнер
        public ReportLogic(IFurnitureStorage furnitureStorage, IOrderStorage orderStorage, IShopStorage shopStorage,
            AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _furnitureStorage = furnitureStorage;
            _orderStorage = orderStorage;
            _shopStorage = shopStorage;

            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        // Получение списка компонент с указанием, в каких изделиях используются
        public List<ReportFurnitureWorkPieceViewModel> GetFurnitureWorkPiece()
        {
            var furnitures = _furnitureStorage.GetFullList();

            var list = new List<ReportFurnitureWorkPieceViewModel>();

            foreach (var furniture in furnitures)
            {
                var record = new ReportFurnitureWorkPieceViewModel
                {
                    FurnitureName = furniture.FurnitureName,
                    WorkPieces = new List<(string, int)>(),
                    TotalCount = 0
                };

                foreach (var workPiece in furniture.FurnitureWorkPieces)
                {
                    record.WorkPieces.Add(new(workPiece.Value.Item1.WorkPieceName, workPiece.Value.Item2));
                    record.TotalCount += workPiece.Value.Item2;
                }

                list.Add(record);
            }

            return list;
        }

        // Получение списка изделий с указанием, в каких магазинах в наличии
        public List<ReportShopFurnituresViewModel> GetShopFurnitures()
        {
            var shops = _shopStorage.GetFullList();

            var list = new List<ReportShopFurnituresViewModel>();

            foreach (var shop in shops)
            {
                var record = new ReportShopFurnituresViewModel
                {
                    ShopName = shop.ShopName,
                    Furnitures = new List<(string, int)>(),
                    TotalCount = 0
                };

                foreach (var furniture in shop.ShopFurnitures)
                {
                    record.Furnitures.Add(new(furniture.Value.Item1.FurnitureName, furniture.Value.Item2));
                    record.TotalCount += furniture.Value.Item2;
                }

                list.Add(record);
            }

            return list;
        }

        // Получение списка заказов за определённый период
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderSearchModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
                .Select(x => new ReportOrdersViewModel
                {
                    Id = x.Id,
                    DateCreate = x.DateCreate,
                    FurnitureName = x.FurnitureName,
                    Sum = x.Sum,
                    OrderStatus = x.Status.ToString()
                }).ToList();
        }

        // Получение списка заказов за весь период
        public List<ReportGroupedOrdersViewModel> GetGroupedOrders()
        {
            return _orderStorage.GetFullList()
                    .GroupBy(x => x.DateCreate.Date)
                    .Select(x => new ReportGroupedOrdersViewModel
                    {
                        DateCreate = x.Key,
                        Count = x.Count(),
                        Sum = x.Sum(x => x.Sum)
                    })
                    .ToList();
        }

        // Сохранение мебели в файл-Word
        public void SaveFurnituresToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Furnitures = _furnitureStorage.GetFullList()
            });
        }

        // Сохранение магазинов в файл-Word
        public void SaveShopsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateTable(new WordInfo
            {
                FileName = model.FileName,
                Title = "Таблица магазинов",
                Shops = _shopStorage.GetFullList()
            });
        }

        // Сохранение заготовок с указанием изделий в файл_Excel
        public void SaveFurnitureWorkPieceToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заготовок",
                FurnitureWorkPieces = GetFurnitureWorkPiece()
            });
        }

        // Сохранение магазинов с указанием изделий в файл-Excel
        public void SaveShopFurnituresToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateShopReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список магазинов",
                ShopFurnitures = GetShopFurnitures()
            });
        }

        // Сохранение заказов в файл-Pdf
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom!.Value,
                DateTo = model.DateTo!.Value,
                Orders = GetOrders(model)
            });
        }

        //Сохранение заказов за весь период в файл-Pdf
        public void SaveGroupedOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateGroupedDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                GroupedOrders = GetGroupedOrders()
            });
        }
    }
}
