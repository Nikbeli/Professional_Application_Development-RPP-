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
		private readonly DataFileSingleton source;

		public ImplementerStorage()
		{
			source = DataFileSingleton.GetInstance();
		}

		public ImplementerViewModel? GetElement(ImplementerSearchModel model)
		{
			if (model.Id.HasValue) 
				return source.Implementers
					.FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
			
			if (model.ImplementerFIO != null && model.Password != null) 
				return source.Implementers.FirstOrDefault(x => x.ImplementerFIO
				.Equals(model.ImplementerFIO) && x.Password.Equals(model.Password))?.GetViewModel;
			
			if (model.ImplementerFIO != null) 
				return source.Implementers
					.FirstOrDefault(x => x.ImplementerFIO.Equals(model.ImplementerFIO))?.GetViewModel;
			
			return null;
		}


		public List<ImplementerViewModel> GetFullList()
		{
			return source.Implementers.Select(x => x.GetViewModel).ToList();
		}

		public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
		{
			if (model == null)
			{
				return new();
			}

			if (model.ImplementerFIO != null)
			{
				return source.Implementers
					.Where(x => x.ImplementerFIO.Contains(model.ImplementerFIO))
					.Where(x => x.Id == model.Id)
					.Select(x => x.GetViewModel)
					.ToList();
			}

			return new();
		}

		public ImplementerViewModel? Insert(ImplementerBindingModel model)
		{
			model.Id = source.Implementers.Count > 0 ? source.Implementers.Max(x => x.Id) + 1 : 1;

			var newImplementer = Implementer.Create(model);

			if (newImplementer == null)
			{
				return null;
			}

			source.Implementers.Add(newImplementer);
			source.SaveImplementers();

			return newImplementer.GetViewModel;
		}

		public ImplementerViewModel? Update(ImplementerBindingModel model)
		{
			var implementer = source.Implementers.FirstOrDefault(x => x.Id == model.Id);

			if (implementer == null)
			{
				return null;
			}

			implementer.Update(model);
			source.SaveImplementers();

			return implementer.GetViewModel;
		}

		public ImplementerViewModel? Delete(ImplementerBindingModel model)
		{
			var element = source.Implementers.FirstOrDefault(x => x.Id == model.Id);

			if (element != null)
			{
				source.Implementers.Remove(element);
				source.SaveImplementers();

				return element.GetViewModel;
			}

			return null;
		}
	}
}
