using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDataModels.Models
{
    // Интерфейс сущности "Магазин"
    public interface IShopModel : IId
    {
        // Название магазина
        string ShopName { get; }

        // Адрес магазина
        string Address { get; }

        // Дата открытия магазина
        DateTime DateOpen { get; }

        // Изделия в магазине
        Dictionary<int, (IFurnitureModel, int)> Furnitures { get; }
    }
}