using FurnitureAssemblyContracts.Attributes;
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
        [Column(visible: false)]
        public int Id { get; set; }

        [Column(visible: false)]
        public string MessageId { get; set; } = string.Empty;

        [Column(visible: false)]
        public int? ClientId { get; set; }

        [Column(title: "Отправитель", width: 150)]
        public string SenderName { get; set; } = string.Empty;

        [Column(title: "Дата отправки", width: 150, format: "D")]
        public DateTime DateDelivery { get; set; } = DateTime.Now;

        [Column(title: "Заголовок", width: 150)]
        public string Subject { get; set; } = string.Empty;

        [DisplayName("Текст")]
        public string Body { get; set; } = string.Empty;

        [DisplayName("Прочитано")]
        public bool IsRead { get; set; } = false;

        [DisplayName("Ответ")]
        public string? Answer { get; set; }
    }
}
