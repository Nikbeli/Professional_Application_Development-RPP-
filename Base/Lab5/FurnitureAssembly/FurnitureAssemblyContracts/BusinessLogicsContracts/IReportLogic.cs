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

        // Получение списка заказов за определённый период
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        // Сохранение изделий в файл-Word
        void SaveFurnituresToWordFile(ReportBindingModel model);

        // Сохранение заготовок с указанием изделий в файл-Excel
        void SaveFurnitureWorkPieceToExcelFile(ReportBindingModel model);

        // Сохранение заказов в файл-Pdf
        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}
