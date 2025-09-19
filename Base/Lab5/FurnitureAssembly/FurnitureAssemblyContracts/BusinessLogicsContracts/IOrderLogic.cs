using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BusinessLogicsContracts
{
    // Бизнес-логика заказов
    public interface IOrderLogic
    {
        List<OrderViewModel>? ReadList(OrderSearchModel? model);

        bool CreateOrder(OrderBindingModel model);

        bool TakeOrderInWork(OrderBindingModel model);

        bool FinishOrder(OrderBindingModel model);

        bool DeliveryOrder(OrderBindingModel model);
    }
}