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
	// Класс, реализующий интерфейс хранилища заказов
	public class OrderStorage : IOrderStorage
	{
		// Поле для работы со списком заказов
		private readonly DataListSingleton _source;

		// Получение в конструкторе объекта DataListSingleton
		public OrderStorage()
		{
			_source = DataListSingleton.GetInstance();
		}

		// Получение полного списка заготовок
		public List<OrderViewModel> GetFullList()
		{
			var result = new List<OrderViewModel>();

			foreach (var order in _source.Orders)
			{
				result.Add(GetViewModel(order));
			}

			return result;
		}

		// Получение отфильтрованного списка заказов
		public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
		{
			var result = new List<OrderViewModel>();

			if (!model.Id.HasValue)
			{
				return result;
			}

			foreach (var order in _source.Orders)
			{
				if (order.Id == model.Id)
				{
					result.Add(GetViewModel(order));
				}
			}

			return result;
		}

		// Получение элемента из списка заказов
		public OrderViewModel? GetElement(OrderSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}

			foreach (var order in _source.Orders)
			{
				if (model.Id.HasValue && order.Id == model.Id)
				{
					return GetViewModel(order);
				}
			}

			return null;
		}

		// Метод для записи названия изделия на форме с заказами
		private OrderViewModel GetViewModel(Order order)
		{
			var viewModel = order.GetViewModel;

			foreach (var furniture in _source.Furnitures)
			{
				if (furniture.Id == order.FurnitureId)
				{
					viewModel.FurnitureName = furniture.FurnitureName;

					break;
				}
			}

			return viewModel;
		}

		// При создании заказа определяем для него новый id: ищем max id и прибавляем к нему 1
		public OrderViewModel? Insert(OrderBindingModel model)
		{
			model.Id = 1;

			foreach (var order in _source.Orders)
			{
				if (model.Id <= order.Id)
				{
					model.Id = order.Id + 1;
				}
			}

			var newOrder = Order.Create(model);

			if (newOrder == null)
			{
				return null;
			}

			_source.Orders.Add(newOrder);

			return GetViewModel(newOrder);
		}

		// Обновление заказа
		public OrderViewModel? Update(OrderBindingModel model)
		{
			foreach (var order in _source.Orders)
			{
				if (order.Id == model.Id)
				{
					order.Update(model);

					return GetViewModel(order);
				}
			}

			return null;
		}

		// Удаление заказа
		public OrderViewModel? Delete(OrderBindingModel model)
		{
			for (int i = 0; i < _source.Orders.Count; i++)
			{
				if (_source.Orders[i].Id == model.Id)
				{
					var element = _source.Orders[i];
					_source.Orders.RemoveAt(i);

					return GetViewModel(element);
				}
			}

			return null;
		}
	}
}
