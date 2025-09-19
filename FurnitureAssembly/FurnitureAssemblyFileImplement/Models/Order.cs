﻿using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Enums;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FurnitureAssemblyFileImplement.Models
{
    // Класс, реализующий интерфейс модели заказа
    [DataContract]
    public class Order : IOrderModel
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public int FurnitureId { get; private set; }

        [DataMember]
        public int ClientId { get; private set; }

        [DataMember]
        public int? ImplementerId { get; private set; }

        [DataMember]
        public int Count { get; private set; }

        [DataMember]
        public double Sum { get; private set; }

        [DataMember]
        public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;

        [DataMember]
        public DateTime DateCreate { get; private set; } = DateTime.Now;

        [DataMember]
        public DateTime? DateImplement { get; private set; }

        public static Order? Create(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Order()
            {
                Id = model.Id,
                FurnitureId = model.FurnitureId,
                ClientId = model.ClientId,
                ImplementerId = model.ImplementerId,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement
            };
        }

        public static Order? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }

            return new Order()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                FurnitureId = Convert.ToInt32(element.Element("FurnitureId")!.Value),
                ClientId = Convert.ToInt32(element.Attribute("Id")!.Value),
                ImplementerId = Convert.ToInt32(element.Element("ImplementerId")!.Value),
                Count = Convert.ToInt32(element.Element("Count")!.Value),
                Sum = Convert.ToDouble(element.Element("Sum")!.Value),
                Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), element.Element("Status")!.Value),
                DateCreate = Convert.ToDateTime(element.Element("DateCreate")!.Value),
                DateImplement = string.IsNullOrEmpty(element.Element("DateImplement")!.Value) ? null :
                Convert.ToDateTime(element.Element("DateImplement")!.Value)
            };
        }

        public void Update(OrderBindingModel model)
        {
            if (model == null)
            {
                return;
            }

            ImplementerId = model.ImplementerId;
            Status = model.Status;
            DateImplement = model.DateImplement;
        }

        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            FurnitureId = FurnitureId,
            ClientId = ClientId,
            ImplementerId = ImplementerId,
            ImplementerFIO = DataFileSingleton.GetInstance().Implementers.FirstOrDefault(x => x.Id == ImplementerId)?.ImplementerFIO ?? string.Empty,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement
        };

        public XElement GetXElement => new("Order",
            new XAttribute("Id", Id),
            new XElement("FurnitureId", FurnitureId.ToString()),
            new XElement("ClientId", ClientId.ToString()),
            new XElement("ImplementerId", ImplementerId),
            new XElement("Count", Count.ToString()),
            new XElement("Sum", Sum.ToString()),
            new XElement("Status", Status.ToString()),
            new XElement("DateCreate", DateCreate.ToString()),
            new XElement("DateImplement", DateImplement.ToString()));
    }
}
