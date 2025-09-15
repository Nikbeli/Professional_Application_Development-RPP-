using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.ViewModels
{
    // Класс для отображения пользователю информации о сообщениях
    public class MessageInfoViewModel : IMessageInfoModel
    {
        public string MessageId { get; set; } = string.Empty;

        public int? ClientId {  get; set; }

        [DisplayName("Отправитель")]
        public string SenderName { get; set; } = string.Empty;

        [DisplayName("Дата отправки")]
        public DateTime DateDelivery { get; set; } = DateTime.Now;

        [DisplayName("Заголовок")]
        public string Subject { get; set; } = string.Empty;

        [DisplayName("Текст")]
        public string Body { get; set; } = string.Empty;
    }
}
