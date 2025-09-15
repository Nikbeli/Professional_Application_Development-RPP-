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
	public class ClientStorage : IClientStorage
	{
		// Поле для работы со списком клиентов
		private readonly DataListSingleton _source;

		public ClientStorage()
		{
			_source = DataListSingleton.GetInstance();
		}

		public ClientViewModel? GetElement(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Email) && !model.Id.HasValue)
			{
				return null;
			}

			foreach (var client in _source.Clients)
			{
				if ((!string.IsNullOrEmpty(model.Email) && client.Email == model.Email) ||
					(model.Id.HasValue && client.Id == model.Id))
				{
					return client.GetViewModel;
				}
			}

			return null;
		}

		public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
		{
			var result = new List<ClientViewModel>();

			if (string.IsNullOrEmpty(model.Email))
			{
				return result;
			}

			foreach (var client in _source.Clients)
			{
				if (client.Email.Contains(model.Email))
				{
					result.Add(client.GetViewModel);
				}
			}

			return result;
		}

		public List<ClientViewModel> GetFullList()
		{
			var result = new List<ClientViewModel>();

			foreach (var client in _source.Clients)
			{
				result.Add(client.GetViewModel);
			}

			return result;
		}

		public ClientViewModel? Insert(ClientBindingModel model)
		{
			model.Id = 1;

			foreach (var client in _source.Clients)
			{
				if (model.Id <= client.Id)
				{
					model.Id = client.Id + 1;
				}
			}

			var newClient = Client.Create(model);

			if (newClient == null)
			{
				return null;
			}

			_source.Clients.Add(newClient);

			return newClient.GetViewModel;
		}

		public ClientViewModel? Update(ClientBindingModel model)
		{
			foreach (var client in _source.Clients)
			{
				if (client.Id == model.Id)
				{
					client.Update(model);

					return client.GetViewModel;
				}
			}

			return null;
		}

		public ClientViewModel? Delete(ClientBindingModel model)
		{
			for (int i = 0; i < _source.Clients.Count; ++i)
			{
				if (_source.Clients[i].Id == model.Id)
				{
					var element = _source.Clients[i];
					_source.Clients.RemoveAt(i);
					return element.GetViewModel;
				}
			}

			return null;
		}
	}
}
