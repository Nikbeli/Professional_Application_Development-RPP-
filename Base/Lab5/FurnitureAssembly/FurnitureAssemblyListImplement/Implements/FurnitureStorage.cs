using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyListImplement.Implements
{
    // Класс, реализующий интерфейс хранилища изделий
    public class FurnitureStorage : IFurnitureStorage
    {
        // Поле для работы со списком изделий
        private readonly DataListSingleton _source;

        // Получение в конструкторе объекта DataListSingleton
        public FurnitureStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        // Получение полного списка изделий
        public List<FurnitureViewModel> GetFullList()
        {
            var result = new List<FurnitureViewModel>();

            foreach(var furniture in _source.Furnitures)
            {
                result.Add(furniture.GetViewModel);
            }

            return result;
        }

        // Получение отфильтрованного списка изделий
        public List<FurnitureViewModel> GetFilteredList(FurnitureSearchModel model)
        {
            var result = new List<FurnitureViewModel>();

            if(string.IsNullOrEmpty(model.FurnitureName))
            {
                return result;
            }

            foreach(var furniture in _source.Furnitures)
            {
                if (furniture.FurnitureName.Contains(model.FurnitureName))
                {
                    result.Add(furniture.GetViewModel);
                }
            }

            return result;
        }

        // Получение элемента из списка изделий
        public FurnitureViewModel? GetElement(FurnitureSearchModel model)
        {
            if (string.IsNullOrEmpty(model.FurnitureName) && !model.Id.HasValue)
            {
                return null;
            }

            foreach(var furniture in _source.Furnitures)
            {
                if((!string.IsNullOrEmpty(model.FurnitureName) && furniture.FurnitureName == model.FurnitureName) ||
                    (model.Id.HasValue && furniture.Id == model.Id))
                {
                    return furniture.GetViewModel;
                }
            }

            return null;
        }

        // При создании изделия определяем для него новый id: ищем max id и прибавлляем к нему 1
        public FurnitureViewModel? Insert(FurnitureBindingModel model)
        {
            model.Id = 1;

            foreach(var furniture in _source.Furnitures)
            {
                if(model.Id <= furniture.Id)
                {
                    model.Id = furniture.Id + 1;
                }
            }

            var newFurniture = Furniture.Create(model);

            if(newFurniture == null)
            {
                return null;
            }

            _source.Furnitures.Add(newFurniture);

            return newFurniture.GetViewModel;
        }

        // Обновление изделия
        public FurnitureViewModel? Update(FurnitureBindingModel model)
        {
            foreach(var furniture in _source.Furnitures)
            {
                if(furniture.Id == model.Id)
                {
                    furniture.Update(model);

                    return furniture.GetViewModel;
                }
            }

            return null;
        }

        // Удаление изделия
        public FurnitureViewModel? Delete(FurnitureBindingModel model)
        {
            for(int i = 0; i < _source.Furnitures.Count; ++i)
            {
                if (_source.Furnitures[i].Id == model.Id)
                {
                    var element = _source.Furnitures[i];
                    _source.Furnitures.RemoveAt(i);

                    return element.GetViewModel;
                }
            }

            return null;
        }
    }
}
