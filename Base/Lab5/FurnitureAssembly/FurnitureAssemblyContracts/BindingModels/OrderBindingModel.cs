using FurnitureAssemblyDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BindingModels
{
    // Реализация сущности "Заказ"
    public class OrderBindingModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int FurnitureId { get; set; }

        public int Count { get; set; }

        public double Sum { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;

        public DateTime DateCreate { get; set; } = DateTime.Now;

        public DateTime? DateImplement { get; set; }
    }
}