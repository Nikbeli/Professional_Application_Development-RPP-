using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Enums;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FurnitureAssemblyFileImplement.Models
{
    // Класс, реализующий интерфейс модели заказа
    public class Order : IOrderModel
    {
        public int Id { get; private set; }

        public int FurnitureId { get; private set; }

        public int Count {  get; private set; }

        public double Sum { get; private set; }

        public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;

        public DateTime DateCreate { get; private set; } = DateTime.Now;

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

            Status = model.Status;
            DateImplement = model.DateImplement;
        }

        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            FurnitureId = FurnitureId,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement
        };

        public XElement GetXElement => new("Order",
            new XAttribute("Id", Id),
            new XElement("FurnitureId", FurnitureId.ToString()),
            new XElement("Count", Count.ToString()),
            new XElement("Sum", Sum.ToString()),
            new XElement("Status", Status.ToString()),
            new XElement("DateCreate", DateCreate.ToString()),
            new XElement("DateImplement", DateImplement.ToString()));
    }
}
