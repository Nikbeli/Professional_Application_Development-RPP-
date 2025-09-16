﻿using FurnitureAssemblyContracts.BindingModels;
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

            return context.Messages.FirstOrDefault(x => (x.MessageId.Equals(model.MessageId)))
                ?.GetViewModel;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            using var context = new FurnitureAssemblyDatabase();

            var list = new List<MessageInfoViewModel>();

            if (model.ClientId.HasValue)
            {
                list = context.Messages.Where(x => x.ClientId.HasValue && x.ClientId == model.ClientId)
                    .Select(x => x.GetViewModel).ToList();
            }
            else
            {
                list = context.Messages.Select(x => x.GetViewModel).ToList();
            }

            if (!(model.Page.HasValue && model.PageSize.HasValue))
            {
                return list.ToList();
            }

            return list.Skip((model.Page.Value - 1) * model.PageSize.Value)
                .Take(model.PageSize.Value).ToList();
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

        public MessageInfoViewModel? Update(MessageInfoBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();

            var message = context.Messages.FirstOrDefault(x => x.MessageId.Equals(model.MessageId));

            if (message == null)
            {
                return null;
            }

            message.Update(model);
            context.SaveChanges();

            return context.Messages.FirstOrDefault(x => x.MessageId.Equals(model.MessageId))
                ?.GetViewModel;
        }
    }
}
