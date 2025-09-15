using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using FurnitureAssemblyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyFileImplement.Implements
{
    // Реализация интерфейса хранилища магазинов
    public class ShopStorage : IShopStorage
    {
        private readonly DataFileSingleton _source;

        public ShopStorage()
        {
            _source = DataFileSingleton.GetInstance();
        }

        public List<ShopViewModel> GetFullList()
        {
            return _source.Shops.Select(x => x.GetViewModel).ToList();
        }

        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName))
            {
                return new();
            }

            return _source.Shops.Where(x => x.ShopName.Contains(model.ShopName))
                .Select(x => x.GetViewModel).ToList();
        }

        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return null;
            }

            return _source.Shops.FirstOrDefault(x => (!string.IsNullOrEmpty(model.ShopName) && x.ShopName == model.ShopName) 
                || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public ShopViewModel? Insert(ShopBindingModel model)
        {
            model.Id = _source.Shops.Count > 0 ? _source.Shops.Max(x => x.Id) + 1 : 1;

            var newShop = Shop.Create(model);

            if (newShop == null)
            {
                return null;
            }

            _source.Shops.Add(newShop);
            _source.SaveShops();

            return newShop.GetViewModel;
        }

        public ShopViewModel? Update(ShopBindingModel model)
        {
            var shop = _source.Shops.FirstOrDefault(x => x.ShopName.Contains(model.ShopName) || x.Id == model.Id);

            if (shop == null)
            {
                return null;
            }

            shop.Update(model);
            _source.SaveShops();

            return shop.GetViewModel;
        }

        public ShopViewModel? Delete(ShopBindingModel model)
        {
            var element = _source.Shops.FirstOrDefault(x => x.Id == model.Id);

            if (element != null)
            {
                _source.Shops.Remove(element);
                _source.SaveShops();

                return element.GetViewModel;
            }

            return null;
        }

        public bool SellFurnitures(IFurnitureModel model, int count)
        {
            if (_source.Shops.Select(x => x.ShopFurnitures.FirstOrDefault(x => x.Key == model.Id).Value.Item2).Sum() < count)
            {
                return false;
            }

            var list = _source.Shops.Where(x => x.ShopFurnitures.ContainsKey(model.Id));

            foreach (var shop in list)
            {
                if (shop.ShopFurnitures[model.Id].Item2 < count)
                {
                    count -= shop.ShopFurnitures[model.Id].Item2;
                    shop.ShopFurnitures[model.Id] = (shop.ShopFurnitures[model.Id].Item1, 0);
                }
                else
                {
                    shop.ShopFurnitures[model.Id] = (shop.ShopFurnitures[model.Id].Item1, shop.ShopFurnitures[model.Id].Item2 - count);
                    count -= count;
                }

                Update(new()
                {
                    ShopName = shop.ShopName,
                    Address = shop.Address,
                    DateOpen = shop.DateOpen,
                    MaxCountFurnitures = shop.MaxCountFurnitures,
                    ShopFurnitures = shop.ShopFurnitures
                });

                if (count == 0)
                {
                    return true;
                }
            }

            return true;
        }
    }
}
