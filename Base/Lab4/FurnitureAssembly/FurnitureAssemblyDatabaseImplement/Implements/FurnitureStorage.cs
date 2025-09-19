using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Implements
{
    public class FurnitureStorage : IFurnitureStorage
    {
        public List<FurnitureViewModel> GetFullList()
        {
            using var context = new FurnitureAssemblyDatabase();

            return context.Furnitures
                .Include(x => x.WorkPieces)
                .ThenInclude(x => x.WorkPiece)
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<FurnitureViewModel> GetFilteredList(FurnitureSearchModel model)
        {
            if (string.IsNullOrEmpty(model.FurnitureName))
            {
                return new();
            }

            using var context = new FurnitureAssemblyDatabase();

            return context.Furnitures
                .Include(x => x.WorkPieces)
                .ThenInclude(x => x.WorkPiece)
                .Where(x => x.FurnitureName.Contains(model.FurnitureName))
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public FurnitureViewModel? GetElement(FurnitureSearchModel model)
        {
            if(string.IsNullOrEmpty(model.FurnitureName) && !model.Id.HasValue)
            {
                return null;
            }

            using var context = new FurnitureAssemblyDatabase();

            return context.Furnitures
                .Include(x => x.WorkPieces)
                .ThenInclude(x => x.WorkPiece)
                .FirstOrDefault(x => (!string.IsNullOrEmpty(model.FurnitureName) && x.FurnitureName == model.FurnitureName) ||
                        model.Id.HasValue && x.Id == model.Id)?.GetViewModel;
        }

        public FurnitureViewModel? Insert(FurnitureBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            var newFurniture = Furniture.Create(context, model);

            if (newFurniture == null)
            {
                return null;
            }

            context.Furnitures.Add(newFurniture);
            context.SaveChanges();

            return newFurniture.GetViewModel;
        }

        public FurnitureViewModel? Update(FurnitureBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var furniture = context.Furnitures.FirstOrDefault(rec => rec.Id == model.Id);

                if (furniture == null)
                {
                    return null;
                }

                furniture.Update(model);
                context.SaveChanges();
                furniture.UpdateWorkPieces(context, model);
                transaction.Commit();

                return furniture.GetViewModel;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public FurnitureViewModel? Delete(FurnitureBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            var element = context.Furnitures
                .Include(x => x.WorkPieces)
                .Include(x => x.Orders)
                .FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                context.Furnitures.Remove(element);
                context.SaveChanges();

                return element.GetViewModel;
            }

            return null;
        }
    }
}
