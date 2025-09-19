﻿using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FurnitureAssemblyFileImplement.Models
{
    public class MessageInfo : IMessageInfoModel
    {
        public string MessageId { get; private set; } = string.Empty;

        public int? ClientId { get; private set; }

        public bool IsRead { get; private set; } = false;

        public string SenderName { get; private set; } = string.Empty;

        public DateTime DateDelivery { get; private set; } = DateTime.Now;

        public string Subject { get; private set; } = string.Empty;

        public string Body { get; private set; } = string.Empty;

        public string? Answer { get; private set; } = string.Empty;

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
                Subject = model.Subject,
                DateDelivery = model.DateDelivery,
                IsRead = model.IsRead,
                Answer = model.Answer
            };
        }

        public static MessageInfo? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }

            return new MessageInfo()
            {
                MessageId = element.Element("MessageId")!.Value,
                ClientId = Convert.ToInt32(element.Attribute("ClientId")!.Value),
                SenderName = element.Element("SenderName")!.Value,
                Body = element.Element("Body")!.Value,
                Subject = element.Element("Subject")!.Value,
                DateDelivery = Convert.ToDateTime(element.Element("DateDelivery")!.Value),
                IsRead = Convert.ToBoolean(element.Element("IsRead")!.Value),
                Answer = element.Element("Answer")!.Value
            };
        }

        public void Update(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return;
            }

            MessageId = model.MessageId;
            ClientId = model.ClientId;
            SenderName = model.SenderName;
            Body = model.Body;
            Subject = model.Subject;
            DateDelivery = model.DateDelivery;
            IsRead = model.IsRead;
            Answer = model.Answer;

        }

        public MessageInfoViewModel GetViewModel => new()
        {
            MessageId = MessageId,
            ClientId = ClientId,
            SenderName = SenderName,
            Body = Body,
            Subject = Subject,
            DateDelivery = DateDelivery,
            IsRead = IsRead,
            Answer = Answer
        };

        public XElement GetXElement => new("MessageInfo",
            new XAttribute("MessageId", MessageId),
            new XElement("ClientId", ClientId.ToString()),
            new XElement("SenderName", SenderName),
            new XElement("Body", Body),
            new XElement("Subject", Subject),
            new XElement("DateDelivery", DateDelivery.ToString()),
            new XElement("IsRead", IsRead),
            new XElement("Answer", Answer));
    }
}
