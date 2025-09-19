﻿using FurnitureAssemblyContracts.BindingModels;
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
    public class ImplementerStorage : IImplementerStorage
    {
        // Поле для работы со списком исполнителей
        private readonly DataListSingleton _source;

        public ImplementerStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        public List<ImplementerViewModel> GetFullList()
        {
            var result = new List<ImplementerViewModel>();

            foreach (var implementer in _source.Implementers)
            {
                result.Add(implementer.GetViewModel);
            }

            return result;
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
        {
            var result = new List<ImplementerViewModel>();

            if (string.IsNullOrEmpty(model.ImplementerFIO))
            {
                return result;
            }

            foreach (var implementer in _source.Implementers)
            {
                if (implementer.ImplementerFIO.Contains(model.ImplementerFIO))
                {
                    result.Add(implementer.GetViewModel);
                }
            }

            return result;
        }

        public ImplementerViewModel? GetElement(ImplementerSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ImplementerFIO) && !model.Id.HasValue)
            {
                return null;
            }

            foreach (var implementer in _source.Implementers)
            {
                if ((!string.IsNullOrEmpty(model.ImplementerFIO) && implementer.ImplementerFIO == model.ImplementerFIO) ||
                    (model.Id.HasValue && implementer.Id == model.Id))
                {
                    return implementer.GetViewModel;
                }
            }

            return null;
        }

        public ImplementerViewModel? Insert(ImplementerBindingModel model)
        {
            model.Id = 1;

            foreach (var implementer in _source.Implementers)
            {
                if (model.Id <= implementer.Id)
                {
                    model.Id = implementer.Id + 1;
                }
            }

            var newImplementer = Implementer.Create(model);

            if (newImplementer == null)
            {
                return null;
            }

            _source.Implementers.Add(newImplementer);

            return newImplementer.GetViewModel;
        }

        public ImplementerViewModel? Update(ImplementerBindingModel model)
        {
            foreach (var implementer in _source.Implementers)
            {
                if (implementer.Id == model.Id)
                {
                    implementer.Update(model);

                    return implementer.GetViewModel;
                }
            }

            return null;
        }

        public ImplementerViewModel? Delete(ImplementerBindingModel model)
        {
            for (int i = 0; i < _source.Implementers.Count; ++i)
            {
                if (_source.Implementers[i].Id == model.Id)
                {
                    var element = _source.Implementers[i];
                    _source.Implementers.RemoveAt(i);

                    return element.GetViewModel;
                }
            }

            return null;
        }
    }
}
