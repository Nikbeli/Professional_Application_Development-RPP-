using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.BussinessLogic
{
    // Класс, реализующий логику для магазинов
    public class ShopLogic : IShopLogic
    {
        private readonly ILogger _logger;

        private readonly IShopStorage _shopStorage;

        // Конструктор
        public ShopLogic(ILogger<ShopLogic> logger, IShopStorage shopStorage)
        {
            _logger = logger;
            _shopStorage = shopStorage;
        }

        // Вывод конкретного магазина
        public ShopViewModel? ReadElement(ShopSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _logger.LogInformation("ReadElement. ShopName:{ShopName}. Id:{Id}", model.ShopName, model.Id);
            var element = _shopStorage.GetElement(model);

            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }

            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);

            return element;
        }

        // Вывод отфильтрованного списка компонентов
        public List<ShopViewModel>? ReadList(ShopSearchModel? model)
        {
            _logger.LogInformation("ReadList. ShopName:{ShopName}. Id: {Id}", model?.ShopName, model?.Id);

            // list хранит весь список в случае, если model пришло со значением null на вход метода
            var list = model == null ? _shopStorage.GetFullList() : _shopStorage.GetFilteredList(model);

            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }

            _logger.LogInformation("ReadList. Count:{Count}", list.Count);

            return list;
        }

        // Пополнение магазина
        public bool AddFurniture(ShopSearchModel model, IFurnitureModel furniture, int count)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (count <= 0)
            {
                throw new ArgumentNullException("Количество добавляемых изделий должно быть больше 0", nameof(count));
            }

            _logger.LogInformation("AddFurniture. ShopName:{ShopName}. Id: {Id}", model?.ShopName, model?.Id);
            var shop = _shopStorage.GetElement(model!);

            if (shop == null)
            {
                _logger.LogWarning("Add Furniture operation failed");
                return false;
            }

            if (!shop.Furnitures.ContainsKey(furniture.Id))
            {
                shop.Furnitures[furniture.Id] = (furniture, count);
            }
            else
            {
                shop.Furnitures[furniture.Id] = (furniture, shop.Furnitures[furniture.Id].Item2 + count);
            }

            _shopStorage.Update(new ShopBindingModel()
            {
                ShopName = shop.ShopName,
                Address = shop.Address,
                DateOpen = shop.DateOpen,
                Furnitures = shop.Furnitures
            });

            return true;
        }

        // Создание магазина
        public bool Create(ShopBindingModel model)
        {
            CheckModel(model);

            if (_shopStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }

            return true;
        }

        // Обновление магазина
        public bool Update(ShopBindingModel model)
        {
            CheckModel(model);

            if (_shopStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }

            return true;
        }

        // Удаление магазина
        public bool Delete(ShopBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);

            if (_shopStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }

            return true;
        }

        // Проверка входного аргумента для методов Insert, Update и Delete
        private void CheckModel(ShopBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            // При удалении передаём как параметр false
            if (!withParams)
            {
                return;
            }

            // Проверка на наличие названия магазина
            if (string.IsNullOrEmpty(model.ShopName))
            {
                throw new ArgumentNullException("Отсутствует названия магазина", nameof(model.ShopName));
            }

            // Проверка на наличие адреса у магазина
            if (string.IsNullOrEmpty(model.Address))
            {
                throw new ArgumentNullException("Отсутствует адреса магазина", nameof(model.Address));
            }

            _logger.LogInformation("Shop. ShopName:{ShopName}. Address:{Address}. Id: {Id}", model.ShopName, model.Address, model.Id);

            // Проверка на наличие такого же магазина в списке
            var element = _shopStorage.GetElement(new ShopSearchModel
            {
                ShopName = model.ShopName
            });

            // Если элемент найден и его Id не совпадает с Id переданного объекта
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Магазин с таким названием уже есть");
            }
        }
    }
}
