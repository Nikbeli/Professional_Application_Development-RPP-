using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BusinessLogicsContracts
{
    // Бизнес-логика для магазина
    public interface IShopLogic
    {
        List<ShopViewModel>? ReadList(ShopSearchModel? model);

        ShopViewModel? ReadElement(ShopSearchModel model);

        bool Create(ShopBindingModel model);

        bool Update(ShopBindingModel model);

        bool Delete(ShopBindingModel model);

        bool AddFurniture(ShopSearchModel model, IFurnitureModel furniture, int count);
    }
}