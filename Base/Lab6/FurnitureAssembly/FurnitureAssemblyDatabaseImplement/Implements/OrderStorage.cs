using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }

            using var context = new FurnitureAssemblyDatabase();

			return context.Orders.Include(x => x.Furniture)
					.Include(x => x.Client).Include(x => x.Implementer)
					.FirstOrDefault(x => (model.Status == null || model.Status != null && model.Status.Equals(x.Status)) &&
					(model.ImplementerId.HasValue && x.ImplementerId == model.ImplementerId) ||
					(model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
		}

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            using var context = new FurnitureAssemblyDatabase();

            if (!model.Id.HasValue && !model.DateFrom.HasValue && !model.DateTo.HasValue && !model.ClientId.HasValue && model.Status == null)
            {
                return new();
            }

            return context.Orders
                .Where(x => x.Id == model.Id || model.DateFrom <= x.DateCreate && x.DateCreate <= model.DateTo ||
                x.ClientId == model.ClientId ||	model.Status.Equals(x.Status))
                .Include(x => x.Furniture).Include(x => x.Client)
                .Include(x => x.Implementer).Select(x => x.GetViewModel)
                .ToList();

		}

        public List<OrderViewModel> GetFullList()
        {
            using var context = new FurnitureAssemblyDatabase();

            return context.Orders.Include(x => x.Furniture).Include(x => x.Client)
                .Include(x => x.Implementer)
                .Select(x => x.GetViewModel).ToList();
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            var newOrder = Order.Create(model);

            if (newOrder == null)
            {
                return null;
            }

            using var context = new FurnitureAssemblyDatabase();

            context.Orders.Add(newOrder);
            context.SaveChanges();

            return context.Orders.Include(x => x.Furniture).Include(x => x.Client)
                .Include(x => x.Implementer).FirstOrDefault(x => x.Id == newOrder.Id)?.GetViewModel;
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            var order = context.Orders
                .Include(x => x.Furniture)
                .Include(x => x.Client)
                .Include(x => x.Implementer)
				.FirstOrDefault(x => x.Id == model.Id);

            if (order == null)
            {
                return null;
            }

            order.Update(model);
            context.SaveChanges();

            return context.Orders
                .Include(x => x.Furniture)
                .Include(x => x.Client)
                .Include(x => x.Implementer)
                .FirstOrDefault(x => x.Id == model.Id)
                ?.GetViewModel;
        }

        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                // для более корректного отображения модели
                var deletedElement = context.Orders.Include(x => x.Furniture).Include(x => x.Client)
                    .Include(x => x.Implementer).FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;

                context.Orders.Remove(element);
                context.SaveChanges();

                return deletedElement;
            }

            return null;
        }
    }
}
