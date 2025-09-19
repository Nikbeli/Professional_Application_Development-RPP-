using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.StoragesContracts
{
    // Класс для хранилища магазинов
    public interface IShopStorage
    {
        List<ShopViewModel> GetFullList();

        List<ShopViewModel> GetFilteredList(ShopSearchModel model);

        ShopViewModel? GetElement(ShopSearchModel model);

        ShopViewModel? Insert(ShopBindingModel model);

        ShopViewModel? Update(ShopBindingModel model);

        ShopViewModel? Delete(ShopBindingModel model);

        bool SellFurnitures(IFurnitureModel model, int count);
    }
}