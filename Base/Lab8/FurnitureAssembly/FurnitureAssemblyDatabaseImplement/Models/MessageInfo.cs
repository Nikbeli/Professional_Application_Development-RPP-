using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Models
{
    [DataContract]
    public class MessageInfo : IMessageInfoModel
    {
        public int Id => throw new NotImplementedException();

        [Key]
        [DataMember]
        public string MessageId { get; set; } = string.Empty;

        public int? ClientId { get; set; }

        public string SenderName { get; set; } = string.Empty;

        public DateTime DateDelivery { get; set; } = DateTime.Now;

        public string Subject { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;

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
                Subject = model.Subject
            };
        }

        public MessageInfoViewModel GetViewModel => new()
        {
            MessageId = MessageId,
            ClientId = ClientId,
            SenderName = SenderName,
            Body = Body,
            DateDelivery = DateDelivery,
            Subject = Subject
        };
    }
}
