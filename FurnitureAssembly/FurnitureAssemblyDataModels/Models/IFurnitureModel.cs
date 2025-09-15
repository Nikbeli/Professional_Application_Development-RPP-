using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDataModels.Models
{
	// Интерфейс, отвечающий за продукт
	public interface IFurnitureModel : IId
	{
		// Наименование изделия 
		string FurnitureName { get; }

		// Цена изделия 
		double Price { get; }

		// Словарь, хранящий пары кол-во + компонент и его цена
		Dictionary<int, (IWorkPieceModel, int)> FurnitureWorkPieces { get; }
	}
}
