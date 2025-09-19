using FurnitureAssemblyContracts.Attributes;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.ViewModels
{
    // Класс для отображения пользователю информации о магазинах
    public class ShopViewModel
    {
        [Column(visible: false)]
        public int Id { get; set; }

        [Column(title: "Название магазина", gridViewAutoSize: GridViewAutoSize.AllCells, isUseAutoSize: true)]
        public string ShopName { get; set; } = string.Empty;

        [Column(title: "Адрес магазина", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string Address { get; set; } = string.Empty;

        [Column(title: "Дата открытия", gridViewAutoSize: GridViewAutoSize.AllCells, isUseAutoSize: true, format: "f")]
        public DateTime DateOpen { get; set; } = DateTime.Now;

        [Column(visible: false)]
        public Dictionary<int, (IFurnitureModel, int)> ShopFurnitures { get; set; } = new();

        [Column(title: "Вместимость магазина", gridViewAutoSize: GridViewAutoSize.DisplayedCells, isUseAutoSize: true)]
        public int MaxCountFurnitures { get; set; }

        [Column(visible: false)]
        public List<Tuple<string, int>>? FurnitureCount { get; set; } = new();
    }
}