using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.BussinessLogic
{
    // Класс, реализующий логику для заказов
    public class OrderLogic : IOrderLogic
    {
        private readonly ILogger _logger;

        private readonly IOrderStorage _orderStorage;

        private readonly IShopLogic _shopLogic;

        private readonly IFurnitureStorage _furnitureStorage;

        // Конструктор
        public OrderLogic(ILogger<OrderLogic> logger, IOrderStorage orderStorage, IShopLogic shopLogic, IFurnitureStorage furnitureStorage)
        {
            _logger = logger;
            _orderStorage = orderStorage;
            _shopLogic = shopLogic;
            _furnitureStorage = furnitureStorage;
        }

        // Вывод отфильтрованного списка компонентов
        public List<OrderViewModel>? ReadList(OrderSearchModel? model)
        {
            _logger.LogInformation("ReadList. Id:{Id}", model?.Id);

            // list хранит весь список в случае, если model пришло со значением null на вход метода
            var list = model == null ? _orderStorage.GetFullList() : _orderStorage.GetFilteredList(model);

            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");

                return null;
            }

            _logger.LogInformation("ReadList. Count:{Count}", list.Count);

            return list;
        }

        // Создание чека
        public bool CreateOrder(OrderBindingModel model)
        {
            CheckModel(model);

            if (model.Status != OrderStatus.Неизвестен)
            {
                _logger.LogWarning("Insert operation failed, incorrect order status");
                return false;
            }

            model.Status = OrderStatus.Принят;

            if (_orderStorage.Insert(model) == null)
            {
                model.Status = OrderStatus.Неизвестен;
                _logger.LogWarning("Insert operation failed");
                return false;
            }

            return true;
        }

        public bool TakeOrderInWork(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Выполняется);
        }

        public bool FinishOrder(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Готов);
        }

        public bool DeliveryOrder(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Выдан);
        }

        // Проверка на пустоту входного параметра
        private void CheckModel(OrderBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            // При удалении параметру withParams передаём false
            if (!withParams)
            {
                return;
            }

            // Проверка на наличие товаров в заказе
            if (model.Count <= 0)
            {
                throw new ArgumentNullException("В заказе не может быть 0 изделий", nameof(model.Count));
            }

            // Проверка на наличие нормальной суммарной стоимости чека
            if (model.Sum <= 0)
            {
                throw new ArgumentNullException("Суммарная стоимость заказа должна быть больше 0", nameof(model.Sum));
            }

            // Проверка корректности id у изделий
            if (model.FurnitureId < 0)
            {
                throw new ArgumentNullException("Некорректный id у изделия", nameof(model.FurnitureId));
            }

            // Проверка корректности дат
            if (model.DateCreate > model.DateImplement)
            {
                throw new InvalidOperationException("Дата создания должна быть более ранней, нежели дата завершения");
            }

            _logger.LogInformation("Order. OrderId:{Id}, Sum:{Sum}. FurnitureId:{Id}. Sum:{Sum}", model.Id, model.Sum, model.FurnitureId, model.Sum);
        }

        // Обновление статуса заказа
        public bool StatusUpdate(OrderBindingModel model, OrderStatus newOrderStatus)
        {
            var viewModel = _orderStorage.GetElement(new OrderSearchModel { Id = model.Id });

            // Если не смогли найти указанный заказ по его Id
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            // Проверка на возможность обновления статуса на следующий
            if (viewModel.Status + 1 != newOrderStatus)
            {
                _logger.LogWarning("Status update operation failed. New status " + newOrderStatus.ToString() + "incorrect");
                return false;
            }

            model.Status = newOrderStatus;

            // Проверка на выдачу
            if (model.Status == OrderStatus.Готов)
            {
                model.DateImplement = DateTime.Now;

                var furniture = _furnitureStorage.GetElement(new() { Id = viewModel.FurnitureId });

                if (furniture == null)
                {
                    throw new ArgumentNullException(nameof(furniture));
                }

                if (!_shopLogic.AddFurnitures(furniture, viewModel.Count))
                {
                    throw new Exception($"Невозможно выдать изделия, магазины переполнены. Operation failed. Shop is full.");
                }
            }
            else
            {
                model.DateImplement = viewModel.DateImplement;
            }

            CheckModel(model, false);

            // Финальная проверка на возможность обновления
            if (_orderStorage.Update(model) == null)
            {
                model.Status--;

                _logger.LogWarning("Update operation failed");

                return false;
            }

            return true;
        }
    }
}
