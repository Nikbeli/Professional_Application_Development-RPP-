using FurnitureAssemblyDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDataModels.Models
{
    // Интерфейс, отвечающий за заказ
    public interface IOrderModel : IId
    {
        // Id продукта
        int FurnitureId { get; }

        // Кол-во продуктов
        int Count { get; }

        // Суммарная стоимость продуктов
        double Sum { get; }

        // Статус заказа
        OrderStatus Status { get; }

        // Дата создания заказа
        DateTime DateCreate { get; }

        // Дата завершения заказа (не обязательна к указанию сразу)
        DateTime? DateImplement { get; }
    }
}