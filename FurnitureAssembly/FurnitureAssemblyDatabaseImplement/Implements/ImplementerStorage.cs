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
	public class ImplementerStorage : IImplementerStorage
	{
		public ImplementerViewModel? GetElement(ImplementerSearchModel model)
		{
			using var context = new FurnitureAssemblyDatabase();

			if (model.Id.HasValue)
				return context.Implementers.FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;

			if (model.ImplementerFIO != null && model.Password != null)
				return context.Implementers.FirstOrDefault(x => x.ImplementerFIO
				.Equals(model.ImplementerFIO) && x.Password.Equals(model.Password))?.GetViewModel;

			if (model.ImplementerFIO != null)
				return context.Implementers.FirstOrDefault(x => x.ImplementerFIO
				.Equals(model.ImplementerFIO))?.GetViewModel;

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
				using var context = new FurnitureAssemblyDatabase();

				return context.Implementers
					.Where(x => x.ImplementerFIO.Contains(model.ImplementerFIO))
					.Select(x => x.GetViewModel)
					.ToList();
			}

			return new();
		}

		public List<ImplementerViewModel> GetFullList()
		{
			using var context = new FurnitureAssemblyDatabase();

			return context.Implementers.Select(x => x.GetViewModel).ToList();
		}

		public ImplementerViewModel? Insert(ImplementerBindingModel model)
		{
			using var context = new FurnitureAssemblyDatabase();

			var res = Implementer.Create(model);

			if (res != null)
			{
				context.Implementers.Add(res);
				context.SaveChanges();
			}

			return res?.GetViewModel;
		}

		public ImplementerViewModel? Update(ImplementerBindingModel model)
		{
			using var context = new FurnitureAssemblyDatabase();

			var res = context.Implementers.FirstOrDefault(x => x.Id == model.Id);

			if (res != null)
			{
				res.Update(model);
				context.SaveChanges();
			}

			return res?.GetViewModel;
		}

		public ImplementerViewModel? Delete(ImplementerBindingModel model)
		{
			using var context = new FurnitureAssemblyDatabase();

			var res = context.Implementers.FirstOrDefault(x => x.Id == model.Id);

			if (res != null)
			{
				context.Implementers.Remove(res);
				context.SaveChanges();
			}

			return res?.GetViewModel;
		}
	}
}
