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
    public class ImplementerStorage : IImplementerStorage
    {
        private readonly DataFileSingleton _source;
        public ImplementerStorage()
        {
            _source = DataFileSingleton.GetInstance();
        }

        public ImplementerViewModel? GetElement(ImplementerSearchModel model)
        {
            if (model.Id.HasValue) 
                return _source.Implementers.FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
            
            if (model.ImplementerFIO != null && model.Password != null) 
                return _source.Implementers.FirstOrDefault(x => x.ImplementerFIO
                .Equals(model.ImplementerFIO) && x.Password.Equals(model.Password))?.GetViewModel;
            
            if (model.ImplementerFIO != null) 
                return _source.Implementers
                    .FirstOrDefault(x => x.ImplementerFIO.Equals(model.ImplementerFIO))?.GetViewModel;
            
            return null;
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
        {
            if (model == null)
            {
                return new();
            }

            if (model.ImplementerFIO != null)
            {
                return _source.Implementers.Where(x => x.ImplementerFIO.Contains(model.ImplementerFIO))
                    .Select(x => x.GetViewModel).ToList();
            }

            return new();
        }

        public List<ImplementerViewModel> GetFullList()
        {
            return _source.Implementers.Select(x => x.GetViewModel).ToList();
        }

        public ImplementerViewModel? Insert(ImplementerBindingModel model)
        {
            model.Id = _source.Implementers.Count > 0 ? _source.Implementers.Max(x => x.Id) + 1 : 1;
            var res = Implementer.Create(model);

            if (res != null)
            {
                _source.Implementers.Add(res);
                _source.SaveImplementers();
            }

            return res?.GetViewModel;
        }

        public ImplementerViewModel? Update(ImplementerBindingModel model)
        {
            var res = _source.Implementers.FirstOrDefault(x => x.Id == model.Id);

            if (res != null)
            {
                res.Update(model);
                _source.SaveImplementers();
            }

            return res?.GetViewModel;
        }

        public ImplementerViewModel? Delete(ImplementerBindingModel model)
        {
            var res = _source.Implementers.FirstOrDefault(x => x.Id == model.Id);

            if (res != null)
            {
                _source.Implementers.Remove(res);
                _source.SaveImplementers();
            }

            return res?.GetViewModel;
        }
    }
}
