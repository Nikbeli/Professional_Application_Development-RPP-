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
	// Класс, реализующий интерфейс модели изделия
	public class Furniture : IFurnitureModel
	{
		public int Id { get; private set; }

		public string FurnitureName { get; private set; } = string.Empty;

		public double Price { get; private set; }

		public Dictionary<int, int> WorkPieces { get; private set; } = new();

		private Dictionary<int, (IWorkPieceModel, int)>? _furnitureWorkPieces = null;

		public Dictionary<int, (IWorkPieceModel, int)> FurnitureWorkPieces
		{
			get
			{
				if (_furnitureWorkPieces == null)
				{
					var source = DataFileSingleton.GetInstance();

					_furnitureWorkPieces = WorkPieces.ToDictionary(x => x.Key,
						y => ((source.WorkPieces.FirstOrDefault(z => z.Id == y.Key) as IWorkPieceModel)!, y.Value));
				}

				return _furnitureWorkPieces;
			}
		}

		public static Furniture? Create(FurnitureBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			return new Furniture()
			{
				Id = model.Id,
				FurnitureName = model.FurnitureName,
				Price = model.Price,
				WorkPieces = model.FurnitureWorkPieces.ToDictionary(x => x.Key, x => x.Value.Item2)
			};
		}

		public static Furniture? Create(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			return new Furniture()
			{
				Id = Convert.ToInt32(element.Attribute("Id")!.Value),
				FurnitureName = element.Element("FurnitureName")!.Value,
				Price = Convert.ToDouble(element.Element("Price")!.Value),
				WorkPieces = element.Element("FurnitureWorkPieces")!.Elements("FurnitureWorkPieces").ToDictionary(
					x => Convert.ToInt32(x.Element("Key")?.Value),
					y => Convert.ToInt32(y.Element("Value")?.Value))
			};
		}

		public void Update(FurnitureBindingModel model)
		{
			if (model == null)
			{
				return;
			}

			FurnitureName = model.FurnitureName;
			Price = model.Price;
			WorkPieces = model.FurnitureWorkPieces.ToDictionary(x => x.Key, x => x.Value.Item2);
			_furnitureWorkPieces = null;
		}

		public FurnitureViewModel GetViewModel => new()
		{
			Id = Id,
			FurnitureName = FurnitureName,
			Price = Price,
			FurnitureWorkPieces = FurnitureWorkPieces
		};

		public XElement GetXElement => new("Furniture",
			new XAttribute("Id", Id),
			new XElement("FurnitureName", FurnitureName),
			new XElement("Price", Price.ToString()),
			new XElement("FurnitureWorkPieces", WorkPieces.Select(
				x => new XElement("FurnitureWorkPieces",
					new XElement("Key", x.Key),
					new XElement("Value", x.Value))
				).ToArray()));
	}
}
