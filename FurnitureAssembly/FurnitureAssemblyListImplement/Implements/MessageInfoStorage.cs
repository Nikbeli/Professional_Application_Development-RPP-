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
    public class MessageInfoStorage : IMessageInfoStorage
    {
        // Поле для работы со списком изделий
        private readonly DataListSingleton _source;

        public MessageInfoStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
        {
            foreach (var message in _source.MessageInfos)
            {
                if (model.MessageId != null && model.MessageId.Equals(message.MessageId))
                    return message.GetViewModel;
            }

            return null;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            List<MessageInfoViewModel> result = new();
            
            foreach (var item in _source.MessageInfos)
            {
                if (item.ClientId.HasValue && item.ClientId == model.ClientId)
                {
                    result.Add(item.GetViewModel);
                }
            }

            if (!(model.Page.HasValue && model.PageSize.HasValue))
            {
                return result;
            }
            
            if (model.Page * model.PageSize >= result.Count)
            {
                return null;
            }

            List<MessageInfoViewModel> filteredResult = new();
            
            for (var i = (model.Page.Value - 1) * model.PageSize.Value; i < model.Page.Value * model.PageSize.Value; i++)
            {
                filteredResult.Add(result[i]);
            }

            return filteredResult;
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            List<MessageInfoViewModel> result = new();
            
            foreach (var item in _source.MessageInfos)
            {
                result.Add(item.GetViewModel);
            }

            return result;
        }

        public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
        {
            var newMessage = MessageInfo.Create(model);
            
            if (newMessage == null)
            {
                return null;
            }

            _source.MessageInfos.Add(newMessage);
            return newMessage.GetViewModel;
        }

        public MessageInfoViewModel? Update(MessageInfoBindingModel model)
        {
            foreach (var message in _source.MessageInfos)
            {
                if (message.MessageId.Equals(model.MessageId))
                {
                    message.Update(model);
                    return message.GetViewModel;
                }
            }

            return null;
        }
    }
}
