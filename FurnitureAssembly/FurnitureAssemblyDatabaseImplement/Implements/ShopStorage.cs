using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDatabaseImplement.Models;
using FurnitureAssemblyDataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Implements
{
    public class ShopStorage : IShopStorage
    {
        public List<ShopViewModel> GetFullList()
        {
            using var context = new FurnitureAssemblyDatabase();

            return context.Shops
                    .Include(x => x.Furnitures)
                    .ThenInclude(x => x.Furniture)
                    .ToList()
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName))
            {
                return new();
            }

            using var context = new FurnitureAssemblyDatabase();

            return context.Shops
                    .Include(x => x.Furnitures)
                    .ThenInclude(x => x.Furniture)
                    .Where(x => x.ShopName.Contains(model.ShopName))
                    .ToList()
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return null;
            }

            using var context = new FurnitureAssemblyDatabase();

            return context.Shops.Include(x => x.Furnitures).ThenInclude(x => x.Furniture)
                .FirstOrDefault(x => (!string.IsNullOrEmpty(model.ShopName) && x.ShopName == model.ShopName) 
                || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public ShopViewModel? Insert(ShopBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            var newShop = Shop.Create(context, model);

            if (newShop == null)
            {
                return null;
            }

            context.Shops.Add(newShop);
            context.SaveChanges();

            return newShop.GetViewModel;
        }

        public ShopViewModel? Update(ShopBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var shop = context.Shops.FirstOrDefault(rec => rec.Id == model.Id);

                if (shop == null)
                {
                    return null;
                }

                shop.Update(model);
                context.SaveChanges();
                shop.UpdateFurnitures(context, model);
                transaction.Commit();

                return shop.GetViewModel;
            }
            catch
            {
                transaction.Rollback();

                throw;
            }
        }

        public ShopViewModel? Delete(ShopBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();

            var element = context.Shops.Include(x => x.Furnitures)
                .FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                context.Shops.Remove(element);
                context.SaveChanges();

                return element.GetViewModel;
            }

            return null;
        }

        public bool SellFurnitures(IFurnitureModel model, int count)
        {
            using var context = new FurnitureAssemblyDatabase();

            using var transaction = context.Database.BeginTransaction();

            try
            {
                var shops = context.ShopFurnitures.Include(x => x.Shop).ToList()
                    .Where(rec => rec.FurnitureId == model.Id);

                if (shops == null)
                {
                    return false;
                }

                foreach (var shop in shops)
                {
                    if (shop.Count < count)
                    {
                        count -= shop.Count;
                        shop.Count = 0;
                    }
                    else
                    {
                        shop.Count = shop.Count - count;
                        count -= count;
                    }

                    if (count == 0)
                    {
                        context.SaveChanges();
                        transaction.Commit();

                        return true;
                    }
                }

                transaction.Rollback();

                return false;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
