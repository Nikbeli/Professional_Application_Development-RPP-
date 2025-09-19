using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyFileImplement.Implements
{
    // Реализация интерфейса хранилища заказов
    public class OrderStorage : IOrderStorage
    {
        private readonly DataFileSingleton source;

        public OrderStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            return source.Orders.Select(x => GetViewModel(x)).ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (!model.Id.HasValue && model.DateFrom.HasValue && model.DateTo.HasValue)
            {
                return source.Orders.Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
                     .Select(x => GetViewModel(x))
                     .ToList();
            }

            return source.Orders.Where(x => x.Id == model.Id).Select(x => GetViewModel(x)).ToList();
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }

            return source.Orders.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        // Для загрузки названий изделия в заказе
        private OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;

            var furniture = source.Furnitures.FirstOrDefault(x => x.Id == order.FurnitureId);

            if(furniture != null)
            {
                viewModel.FurnitureName = furniture.FurnitureName;
            }

            return viewModel;
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = source.Orders.Count > 0 ? source.Orders.Max(x => x.Id) + 1 : 1;

            var newOrder = Order.Create(model);

            if (newOrder == null)
            {
                return null;
            }

            source.Orders.Add(newOrder);
            source.SaveOrders();

            return GetViewModel(newOrder);
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            var order = source.Orders.FirstOrDefault(x => x.Id == model.Id);

            if(order == null)
            {
                return null;
            }

            order.Update(model);
            source.SaveOrders();

            return GetViewModel(order);
        }

        public OrderViewModel? Delete(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(x => x.Id == model.Id);

            if(element != null)
            {
                source.Orders.Remove(element);
                source.SaveOrders();

                return GetViewModel(element);
            }

            return null;
        }
    }
}
