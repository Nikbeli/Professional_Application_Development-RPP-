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
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
        {
            if (string.IsNullOrEmpty(model.MessageId))
            {
                return null;
            }

            using var context = new FurnitureAssemblyDatabase();

            return context.Messages.FirstOrDefault(x => (x.MessageId == model.MessageId))
                ?.GetViewModel;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            using var context = new FurnitureAssemblyDatabase();

            return context.Messages.Where(x => x.ClientId.HasValue && x.ClientId == model.ClientId)
                .Select(x => x.GetViewModel).ToList();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            using var context = new FurnitureAssemblyDatabase();

            return context.Messages.Select(x => x.GetViewModel).ToList();
        }

        public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();

            var newMessage = MessageInfo.Create(model);

            if (newMessage == null)
            {
                return null;
            }

            context.Messages.Add(newMessage);
            context.SaveChanges();

            return newMessage.GetViewModel;
        }
    }
}
