using FurnitureAssemblyContracts.Attributes;
using FurnitureAssemblyDataModels.Enums;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.ViewModels
{
	// Класс для отображения пользователю информации о заказах
	public class OrderViewModel : IOrderModel
	{
		[Column(visible: false)]
		public int Id { get; set; }

		[Column(visible: false)]
		public int ClientId { get; set; }

		[Column(title: "ФИО клиента", width: 150)]
		public string ClientFIO { get; set; } = string.Empty;

		[Column(visible: false)]
		public int? ImplementerId { get; set; }

		[Column(title: "ФИО исполнителя", width: 150)]
		public string ImplementerFIO { get; set; } = string.Empty;

		[Column(visible: false)]
		public int FurnitureId { get; set; }

		[Column(title: "Изделие", width: 150)]
		public string FurnitureName { get; set; } = string.Empty;

		[Column(title: "Количество", width: 150)]
		public int Count { get; set; }

		[Column(title: "Сумма", width: 150)]
		public double Sum { get; set; }

		[Column(title: "Статус", width: 150)]
		public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;

		[Column(title: "Дата создания", width: 150)]
		public DateTime DateCreate { get; set; } = DateTime.Now;

		[Column(title: "Дата выполнения", width: 150)]
		public DateTime? DateImplement { get; set; }
	}
}
