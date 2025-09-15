using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BindingModels
{
    // Реализация сущности "Магазин"
    public class ShopBindingModel : IShopModel
    {
        public string ShopName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime DateOpen { get; set; } = DateTime.Now;

        public Dictionary<int, (IFurnitureModel, int)> Furnitures { get; set; } = new();

        public int Id { get; set; }

        public int MaxCountFurnitures { get; set; }
    }
}