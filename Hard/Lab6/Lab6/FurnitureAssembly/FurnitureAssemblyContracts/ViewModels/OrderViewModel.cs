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
        [DisplayName("Номер")]
        public int Id { get; set; }

        public int FurnitureId { get; set; }

        [DisplayName("Изделие")]
        public string FurnitureName { get; set; } = string.Empty;

        public int ClientId { get; set; }

        [DisplayName("ФИО клиента")]
        public string ClientFIO { get; set; } = string.Empty;

        public int? ImplementerId { get; set; }

        [DisplayName("ФИО исполнителя")]
        public string ImplementerFIO { get; set; } = string.Empty;

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public double Sum { get; set; }

        [DisplayName("Статус")]
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; } = DateTime.Now;

        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}