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

		private readonly AbstractSaveToExcel _saveToExcel;

		private readonly AbstractSaveToWord _saveToWord;

		private readonly AbstractSaveToPdf _saveToPdf;

		// Инициализируем поля класса через контейнер
		public ReportLogic(IFurnitureStorage furnitureStorage,
			IOrderStorage orderStorage, AbstractSaveToExcel saveToExcel,
			AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
		{
			_furnitureStorage = furnitureStorage;
			_orderStorage = orderStorage;

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
	}
}
