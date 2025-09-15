using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        // Получение списка заготовок с указанием, в каких изделиях используются
        List<ReportFurnitureWorkPieceViewModel> GetFurnitureWorkPiece();

        //Получение списка мороженых с указанием, в каких магазинах в наличии
        List<ReportShopFurnituresViewModel> GetShopFurnitures();

        // Получение списка заказов за определённый период
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        //Получение списка заказов за весь период
        List<ReportGroupedOrdersViewModel> GetGroupedOrders();

        // Сохранение изделий в файл-Word
        void SaveFurnituresToWordFile(ReportBindingModel model);

        //Сохранение магазинов в виде таблицы в файл-Word
        void SaveShopsToWordFile(ReportBindingModel model);

        // Сохранение заготовок с указанием изделий в файл-Excel
        void SaveFurnitureWorkPieceToExcelFile(ReportBindingModel model);

        //Сохранение магазинов с указанием мороженых в файл-Excel
        void SaveShopFurnituresToExcelFile(ReportBindingModel model);

        // Сохранение заказов в файл-Pdf
        void SaveOrdersToPdfFile(ReportBindingModel model);

        //Сохранение заказов за весь период в файл-Pdf
        void SaveGroupedOrdersToPdfFile(ReportBindingModel model);
    }
}
