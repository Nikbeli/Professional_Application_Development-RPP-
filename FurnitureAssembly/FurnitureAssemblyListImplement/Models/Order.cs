using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Enums;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyListImplement.Models
{
	// Класс, реализующий интерфейс модели заказа
	public class Order : IOrderModel
	{
		// Методы set сделали приватными, чтобы исключить неразрешённые манипуляции
		public int Id { get; private set; }

		public int ClientId { get; private set; }

		public int FurnitureId { get; private set; }

		public int? ImplementerId { get; private set; }

		public int Count { get; private set; }

		public double Sum { get; private set; }

		public OrderStatus Status { get; private set; }

		public DateTime DateCreate { get; private set; } = DateTime.Now;

		public DateTime? DateImplement { get; private set; }

		public static Order? Create(OrderBindingModel? model)
		{
			if (model == null)
			{
				return null;
			}

			return new Order()
			{
				Id = model.Id,
				FurnitureId = model.FurnitureId,
				ClientId = model.ClientId,
				ImplementerId = model.ImplementerId,
				Count = model.Count,
				Sum = model.Sum,
				Status = model.Status,
				DateCreate = model.DateCreate,
				DateImplement = model.DateImplement,
			};
		}

		// Метод изменения существующего объекта
		public void Update(OrderBindingModel? model)
		{
			if (model == null)
			{
				return;
			}

			Status = model.Status;
			DateImplement = model.DateImplement;
		}

		// Метод для создания объекта класса ViewModel на основе данных объекта класса-компонента
		public OrderViewModel GetViewModel => new()
		{
			Id = Id,
			FurnitureId = FurnitureId,
			ClientId = ClientId,
			ImplementerId = ImplementerId,
			Count = Count,
			Sum = Sum,
			Status = Status,
			DateCreate = DateCreate,
			DateImplement = DateImplement,
		};
	}
}
