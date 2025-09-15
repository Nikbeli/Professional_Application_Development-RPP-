using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Enums;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Models
{
    public class Order : IOrderModel
    {
        public int Id { get; private set; }

        [Required]
        public int FurnitureId { get; private set; }

        [Required]
        public int Count { get; private set; }

        [Required]
        public double Sum { get; private set; }

        [Required]
        public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;

        [Required]
        public DateTime DateCreate { get; private set; } = DateTime.Now;

        public DateTime? DateImplement { get; private set; }

        // Для передачи названия изделия
        public virtual Furniture Furniture { get; set; }

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

            Status = model.Status;
            DateImplement = model.DateImplement;
        }

        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            FurnitureId = FurnitureId,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement,
            FurnitureName = Furniture.FurnitureName
        };
    }
}
