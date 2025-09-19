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
    public class ClientStorage : IClientStorage
    {
        private readonly DataFileSingleton source;

        public ClientStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Email) && !model.Id.HasValue)
            {
                return null;
            }
            return source.Clients
            .FirstOrDefault(x => (!string.IsNullOrEmpty(model.Email) && x.Email == model.Email) 
            || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return new();
            }

            return source.Clients
                .Where(x => x.Email.Contains(model.Email))
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<ClientViewModel> GetFullList()
        {
            return source.Clients.Select(x => x.GetViewModel).ToList();
        }

        public ClientViewModel? Insert(ClientBindingModel model)
        {
            model.Id = source.Clients.Count > 0 ? source.Clients.Max(x => x.Id) + 1 : 1;

            var newClient = Client.Create(model);

            if (newClient == null)
            {
                return null;
            }

            source.Clients.Add(newClient);
            source.SaveClients();

            return newClient.GetViewModel;
        }

        public ClientViewModel? Update(ClientBindingModel model)
        {
            var client = source.Clients.FirstOrDefault(x => x.Id == model.Id);

            if (client == null)
            {
                return null;
            }

            client.Update(model);
            source.SaveClients();

            return client?.GetViewModel;
        }

        public ClientViewModel? Delete(ClientBindingModel model)
        {
            var client = source.Clients.FirstOrDefault(x => x.Id == model.Id);

            if (client != null)
            {
                source.Clients.Remove(client);
                source.SaveClients();

                return client?.GetViewModel;
            }

            return null;
        }
    }
}
