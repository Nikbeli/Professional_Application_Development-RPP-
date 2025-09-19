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
    public class ClientStorage : IClientStorage
    {
        public ClientViewModel? GetElement(ClientSearchModel model)
        {

            using var context = new FurnitureAssemblyDatabase();

            if (model.Id.HasValue)
            {
                return context.Clients
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.Id == model.Id)
                ?.GetViewModel;
            }

            if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
            {
                return context.Clients
                    .Include(x => x.Orders)
                    .FirstOrDefault(x => (x.Email == model.Email && x.Password == model.Password))
                    ?.GetViewModel;
            }

            if (!string.IsNullOrEmpty(model.Email))
                return context.Clients
                    .FirstOrDefault(x => x.Email == model.Email)
                    ?.GetViewModel;

            return null;
        }

        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Email)) 
            { 
                return new(); 
            }

            using var context = new FurnitureAssemblyDatabase();

            return context.Clients
                .Where(x => x.Email.Contains(model.Email))
                .Select(x => x.GetViewModel).ToList();
        }

        public List<ClientViewModel> GetFullList()
        {
            using var context = new FurnitureAssemblyDatabase();
            return context.Clients.Select(x => x.GetViewModel).ToList();
        }

        public ClientViewModel? Insert(ClientBindingModel model)
        {
            var newClient = Client.Create(model);

            if (newClient == null)
            {
                return null;
            }

            using var context = new FurnitureAssemblyDatabase();

            context.Clients.Add(newClient);
            context.SaveChanges();

            return newClient.GetViewModel;
        }

        public ClientViewModel? Update(ClientBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            var client = context.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            client.Update(model);
            context.SaveChanges();
            return client.GetViewModel;
        }

        public ClientViewModel? Delete(ClientBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            
            var client = context.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            context.Clients.Remove(client);
            context.SaveChanges();
            return client.GetViewModel;
        }
    }
}
