using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Models
{
    public class MessageInfo : IMessageInfoModel
    {
        [Key]
        public string MessageId { get; set; } = string.Empty;

        public int? ClientId { get; set; }

        public bool IsRead { get; private set; } = false;

        [Required]
        public string SenderName { get; set; } = string.Empty;

        [Required]
        public DateTime DateDelivery { get; set; } = DateTime.Now;

        [Required]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public string Body { get; set; } = string.Empty;

        public string? Answer { get; private set; } = string.Empty;

        public virtual Client? Client { get; set; }

        public static MessageInfo? Create(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new MessageInfo()
            {
                MessageId = model.MessageId,
                ClientId = model.ClientId,
                SenderName = model.SenderName,
                Body = model.Body,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                IsRead = model.IsRead,
                Answer = model.Answer
            };
        }

        public void Update(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return;
            }

            IsRead = model.IsRead;
            Answer = model.Answer;
        }

        public MessageInfoViewModel GetViewModel => new()
        {
            MessageId = MessageId,
            ClientId = ClientId,
            SenderName = SenderName,
            Body = Body,
            DateDelivery = DateDelivery,
            Subject = Subject,
            IsRead = IsRead,
            Answer = Answer
        };
    }
}
