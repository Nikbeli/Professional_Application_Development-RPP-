using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyFileImplement.Implements
{
    // Реализация интерфейса хранилища изделий
    public class FurnitureStorage : IFurnitureStorage
    {
        private readonly DataFileSingleton source;

        public FurnitureStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public List<FurnitureViewModel> GetFullList()
        {
            return source.Furnitures.Select(x => x.GetViewModel).ToList();
        }

        public List<FurnitureViewModel> GetFilteredList(FurnitureSearchModel model)
        {
            if (string.IsNullOrEmpty(model.FurnitureName))
            {
                return new();
            }

            return source.Furnitures.Where(x => x.FurnitureName.Contains(model.FurnitureName))
                .Select(x => x.GetViewModel).ToList();
        }

        public FurnitureViewModel? GetElement(FurnitureSearchModel model)
        {
            if (string.IsNullOrEmpty(model.FurnitureName) && !model.Id.HasValue)
            {
                return null;
            }

            return source.Furnitures.FirstOrDefault(x => (!string.IsNullOrEmpty(model.FurnitureName) 
                && x.FurnitureName == model.FurnitureName) || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public FurnitureViewModel? Insert(FurnitureBindingModel model)
        {
            model.Id = source.Furnitures.Count > 0 ? source.Furnitures.Max(x => x.Id) + 1 : 1;

            var newFurniture = Furniture.Create(model);

            if (newFurniture == null)
            {
                return null;
            }

            source.Furnitures.Add(newFurniture);
            source.SaveFurnitures();

            return newFurniture.GetViewModel;
        }

        public FurnitureViewModel? Update(FurnitureBindingModel model)
        {
            var furniture = source.Furnitures.FirstOrDefault(x => x.Id == model.Id);

            if (furniture == null)
            {
                return null;
            }

            furniture.Update(model);
            source.SaveFurnitures();

            return furniture.GetViewModel;
        }

        public FurnitureViewModel? Delete(FurnitureBindingModel model)
        {
            var element = source.Furnitures.FirstOrDefault(x => x.Id == model.Id);

            if (element != null)
            {
                source.Furnitures.Remove(element);
                source.SaveFurnitures();

                return element.GetViewModel;
            }

            return null;
        }
    }
}
