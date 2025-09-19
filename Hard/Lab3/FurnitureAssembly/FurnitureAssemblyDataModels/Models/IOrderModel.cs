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
        // id продукта
        int FurnitureId { get; }

        // кол-во продуктов
        int Count { get; }

        // суммарная стоимость продуктов
        double Sum { get; }

        // статус заказа
        OrderStatus Status { get; }

        //дата создания заказа
        DateTime DateCreate { get; }

        //дата завершения заказа (не обязательна к указанию сразу)
        DateTime? DateImplement { get; }
    }
}