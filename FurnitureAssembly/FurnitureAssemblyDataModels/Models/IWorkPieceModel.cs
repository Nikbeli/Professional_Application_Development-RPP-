using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDataModels.Models
{
	// Интерфейс, отвечающий за компоненты
	public interface IWorkPieceModel : IId
	{
		// Название составляющей (изделие состоит из составляющих)
		string WorkPieceName { get; }

		// Цена составляющей
		double Cost { get; }
	}
}
