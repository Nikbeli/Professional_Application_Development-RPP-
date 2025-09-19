using FurnitureAssemblyContracts.BindingModels;
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
    // Класс, реализующий интерфейс модели магазина
    public class Shop : IShopModel
    {
        public int Id { get; set; }

        public string ShopName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime DateOpen { get; set; }

        public int MaxCountFurnitures { get; set; }

        public Dictionary<int, int> countFurniture { get; private set; } = new();

        public Dictionary<int, (IFurnitureModel, int)> _furnitures = null;

        public Dictionary<int, (IFurnitureModel, int)> ShopFurnitures
        {
            get
            {
                if (_furnitures == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _furnitures = countFurniture.ToDictionary(x => x.Key, y => ((source.Furnitures.FirstOrDefault(z => z.Id == y.Key) as IFurnitureModel)!, y.Value));
                }

                return _furnitures;
            }
        }

        public static Shop? Create(ShopBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpen = model.DateOpen,
                MaxCountFurnitures = model.MaxCountFurnitures,
                countFurniture = model.ShopFurnitures.ToDictionary(x => x.Key, x => x.Value.Item2)
            };
        }
        public static Shop? Create(XElement element)

        {
            if (element == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ShopName = element.Element("ShopName")!.Value,
                Address = element.Element("Address")!.Value,
                DateOpen = Convert.ToDateTime(element.Element("DateOpen")!.Value),
                MaxCountFurnitures = Convert.ToInt32(element.Element("MaxCountFurnitures")!.Value),
                countFurniture = element.Element("Furnitures")!.Elements("Furnitures").ToDictionary(x => Convert.ToInt32(x.Element("Key")?.Value), x => Convert.ToInt32(x.Element("Value")?.Value))
            };
        }

        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Address = model.Address;
            DateOpen = model.DateOpen;
            MaxCountFurnitures = model.MaxCountFurnitures;
            countFurniture = model.ShopFurnitures.ToDictionary(x => x.Key, x => x.Value.Item2);
            _furnitures = null;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            MaxCountFurnitures = MaxCountFurnitures,
            ShopFurnitures = ShopFurnitures
        };
        public XElement GetXElement => new("Shop",
            new XAttribute("Id", Id),
            new XElement("ShopName", ShopName),
            new XElement("Address", Address),
            new XElement("DateOpen", DateOpen.ToString()),
            new XElement("MaxCountFurnitures", MaxCountFurnitures.ToString()),
            new XElement("Furnitures", countFurniture.Select(x => new XElement("Furnitures",
                new XElement("Key", x.Key),
                new XElement("Value", x.Value))).ToArray()));
    }
}
