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
        public int Id { get; set; }

        [DisplayName("Название магазина")]
        public string ShopName { get; set; } = string.Empty;

        [DisplayName("Адрес магазина")]
        public string Address { get; set; } = string.Empty;

        [DisplayName("Дата открытия")]
        public DateTime DateOpen { get; set; } = DateTime.Now;

        public Dictionary<int, (IFurnitureModel, int)> Furnitures { get; set; } = new();

        [DisplayName("Вместимость магазина")]
        public int MaxCountFurnitures { get; set; }
    }
}