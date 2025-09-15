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
	// Класс, реализующий интерфейс модели заготовки
	public class WorkPiece : IWorkPieceModel
	{
		public int Id { get; private set; }

		public string WorkPieceName { get; private set; } = string.Empty;

		public double Cost { get; set; }

		public static WorkPiece? Create(WorkPieceBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			return new WorkPiece()
			{
				Id = model.Id,
				WorkPieceName = model.WorkPieceName,
				Cost = model.Cost
			};
		}

		public static WorkPiece? Create(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			return new WorkPiece()
			{
				Id = Convert.ToInt32(element.Attribute("Id")!.Value),
				WorkPieceName = element.Element("WorkPieceName")!.Value,
				Cost = Convert.ToDouble(element.Element("Cost")!.Value)
			};
		}

		public void Update(WorkPieceBindingModel model)
		{
			if (model == null)
			{
				return;
			}

			WorkPieceName = model.WorkPieceName;
			Cost = model.Cost;
		}

		public WorkPieceViewModel GetViewModel => new()
		{
			Id = Id,
			WorkPieceName = WorkPieceName,
			Cost = Cost
		};

		public XElement GetXElement => new("WorkPiece",
			new XAttribute("Id", Id),
			new XElement("WorkPieceName", WorkPieceName),
			new XElement("Cost", Cost.ToString()));
	}
}
