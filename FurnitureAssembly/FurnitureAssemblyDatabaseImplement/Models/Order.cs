using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Enums;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Models
{
	[DataContract]
	public class Order : IOrderModel
	{
		[DataMember]
		public int Id { get; private set; }

		[Required]
		[DataMember]
		public int FurnitureId { get; private set; }

		[Required]
		[DataMember]
		public int ClientId { get; private set; }

		[DataMember]
		public int? ImplementerId { get; private set; }

		[Required]
		[DataMember]
		public int Count { get; private set; }

		[Required]
		[DataMember]
		public double Sum { get; private set; }

		[Required]
		[DataMember]
		public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;

		[Required]
		[DataMember]
		public DateTime DateCreate { get; private set; } = DateTime.Now;

		[DataMember]
		public DateTime? DateImplement { get; private set; }

		// Для передачи названия изделия
		public virtual Furniture Furniture { get; set; }

		// Для передачи имени клиента
		public virtual Client Client { get; set; }

		// Для передачи имени исполнителя
		public virtual Implementer? Implementer { get; set; }

		public static Order? Create(OrderBindingModel model)
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

		public void Update(OrderBindingModel model)
		{
			if (model == null)
			{
				return;
			}

			ImplementerId = model.ImplementerId;
			Status = model.Status;
			DateImplement = model.DateImplement;
		}

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
			FurnitureName = Furniture.FurnitureName,
			ClientFIO = Client.ClientFIO,
			ImplementerFIO = Implementer?.ImplementerFIO ?? string.Empty
		};
	}
}
