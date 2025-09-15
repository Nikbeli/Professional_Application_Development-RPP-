using FurnitureAssemblyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels
{
    // Информация по excel файлу, который хотим создать
    public class ExcelInfo
    {
        // Название файла
        public string FileName { get; set; } = string.Empty;

        // Заголовок
        public string Title { get; set; } = string.Empty;

        // Список заготовок по изделиям
        public List<ReportFurnitureWorkPieceViewModel> FurnitureWorkPieces { get; set; } = new();

        // Список магазинов с изделиями
        public List<ReportShopFurnituresViewModel> ShopFurnitures { get; set; } = new();
    }
}
