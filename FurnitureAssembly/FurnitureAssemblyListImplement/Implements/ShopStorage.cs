using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyListImplement.Implements
{
    // Класс, реализующий интерфейс хранилища магазинов
    public class ShopStorage : IShopStorage
    {
        // Поле для работы со списком магазинов
        private readonly DataListSingleton _source;

        // Получение в конструкторе объекта DataListSingleton
        public ShopStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        // Получение элемента из списка заготовок
        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return null;
            }

            foreach (var shop in _source.Shops)
            {
                if ((!string.IsNullOrEmpty(model.ShopName) && shop.ShopName == model.ShopName) || (model.Id.HasValue && shop.Id == model.Id))
                {
                    return shop.GetViewModel;
                }
            }

            return null;
        }

        // Получение отфильтрованного списка заказов
        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            var result = new List<ShopViewModel>();

            if (string.IsNullOrEmpty(model.ShopName))
            {
                return result;
            }

            foreach (var shop in _source.Shops)
            {
                if (shop.ShopName.Contains(model.ShopName))
                {
                    result.Add(shop.GetViewModel);
                }
            }

            return result;
        }

        // Получение полного списка заготовок
        public List<ShopViewModel> GetFullList()
        {
            var result = new List<ShopViewModel>();

            foreach (var shop in _source.Shops)
            {
                result.Add(shop.GetViewModel);
            }

            return result;
        }

        // При создании магазина определяем для него новый id: ищем max id и прибавляем к нему 1
        public ShopViewModel? Insert(ShopBindingModel model)
        {
            model.Id = 1;

            foreach (var shop in _source.Shops)
            {
                if (model.Id <= shop.Id)
                {
                    model.Id = shop.Id + 1;
                }
            }

            var newShop = Shop.Create(model);

            if (newShop == null)
            {
                return null;
            }

            _source.Shops.Add(newShop);

            return newShop.GetViewModel;
        }

        // Обновление магазина
        public ShopViewModel? Update(ShopBindingModel model)
        {
            foreach (var shop in _source.Shops)
            {
                if (shop.Id == model.Id)
                {
                    shop.Update(model);

                    return shop.GetViewModel;
                }
            }

            return null;
        }

        // Удаление магазина
        public ShopViewModel? Delete(ShopBindingModel model)
        {
            for (int i = 0; i < _source.Shops.Count; ++i)
            {
                if (_source.Shops[i].Id == model.Id)
                {
                    var element = _source.Shops[i];
                    _source.Shops.RemoveAt(i);

                    return element.GetViewModel;
                }
            }

            return null;
        }
    }
}
