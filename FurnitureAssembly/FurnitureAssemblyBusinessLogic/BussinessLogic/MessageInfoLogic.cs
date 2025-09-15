using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.BussinessLogic
{
    // Класс, реализующий логику для сообщений
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly ILogger _logger;

        private readonly IMessageInfoStorage _messageInfoStorage;

        // Конструктор
        public MessageInfoLogic(ILogger<MessageInfoLogic> logger, IMessageInfoStorage messageInfoStorage)
        {
            _logger = logger;
            _messageInfoStorage = messageInfoStorage;
        }

        public List<MessageInfoViewModel>? ReadList(MessageInfoSearchModel? model)
        {
            _logger.LogInformation("ReadList. MessageId:{MessageId}", model?.MessageId);

            // list хранит весь список в случае, если model пришло со значением null на вход метода
            var list = model == null ? _messageInfoStorage.GetFullList() : _messageInfoStorage.GetFilteredList(model);

            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }

            _logger.LogInformation("ReadList. Count:{Count}", list.Count);

            return list.OrderByDescending(x => x.DateDelivery).ToList();
        }

        public bool Create(MessageInfoBindingModel model)
        {
            if (_messageInfoStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }

            return true;
        }
    }
}
