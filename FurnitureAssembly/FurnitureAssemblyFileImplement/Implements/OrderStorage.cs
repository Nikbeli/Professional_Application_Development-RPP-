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
			if (!model.Id.HasValue && !model.DateFrom.HasValue && !model.DateTo.HasValue
				&& !model.ClientId.HasValue)
			{
				return new();
			}

			return source.Orders.Where(x => x.Id == model.Id || model.DateFrom <= x.DateCreate
				&& x.DateCreate <= model.DateTo || x.ClientId == model.ClientId)
					.Select(x => GetViewModel(x)).ToList();
		}

		public OrderViewModel? GetElement(OrderSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}

			return source.Orders.FirstOrDefault(x =>
				(model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
		}

		// Для загрузки названий изделия в заказе
		private OrderViewModel GetViewModel(Order order)
		{
			var viewModel = order.GetViewModel;

			var furniture = source.Furnitures.FirstOrDefault(x => x.Id == order.FurnitureId);

			var client = source.Clients.FirstOrDefault(x => x.Id == order.ClientId);

			if (furniture != null)
			{
				viewModel.FurnitureName = furniture.FurnitureName;
			}

			if (client != null)
			{
				viewModel.ClientFIO = client.ClientFIO;
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

			if (order == null)
			{
				return null;
			}

			order.Update(model);
			source.SaveOrders();

			return GetViewModel(order);
		}

		public OrderViewModel? Delete(OrderBindingModel model)
		{
			var order = source.Orders.FirstOrDefault(x => x.Id == model.Id);

			if (order != null)
			{
				source.Orders.Remove(order);
				source.SaveOrders();

				return GetViewModel(order);
			}

			return null;
		}
	}
}
