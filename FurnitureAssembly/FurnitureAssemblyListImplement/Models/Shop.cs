using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyListImplement.Models
{
    // Класс, реализующий интерфейс модели магазина
    public class Shop : IShopModel
    {
        // Методы set сделали приватными, чтобы исключить неразрешённые манипуляции
        public string ShopName { get; private set; } = string.Empty;

        public string Address { get; private set; } = string.Empty;

        public DateTime DateOpen { get; private set; }

        public int Id { get; private set; }

        public Dictionary<int, (IFurnitureModel, int)> Furnitures { get; private set; } =
            new Dictionary<int, (IFurnitureModel, int)>();

        // Метод для создания объекта от класса-компонента на основе класса-BindingModel
        public static Shop? Create(ShopBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }

            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpen = model.DateOpen,
                Furnitures = model.Furnitures
            };
        }

        // Метод изменения существующего объекта
        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }

            ShopName = model.ShopName;
            Address = model.Address;
            DateOpen = model.DateOpen;
            Furnitures = model.Furnitures;
        }

        // Метод для создания объекта класса ViewModel на основе данных объекта класса-компонента
        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            Furnitures = Furnitures
        };
    }
}