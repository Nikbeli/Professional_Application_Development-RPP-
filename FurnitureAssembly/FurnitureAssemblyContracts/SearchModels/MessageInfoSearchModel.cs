using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.SearchModels
{
    // Модель для поиска сущности "Сообщение"
    public class MessageInfoSearchModel
    {
        public string? MessageId { get; set; }

        public int? ClientId { get; set; }
    }
}
