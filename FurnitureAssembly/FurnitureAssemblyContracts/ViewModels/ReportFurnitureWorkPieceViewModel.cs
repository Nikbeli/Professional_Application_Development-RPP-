using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.ViewModels
{
	public class ReportFurnitureWorkPieceViewModel
	{
		public string FurnitureName { get; set; } = string.Empty;

		public int TotalCount { get; set; }

		// Список кортежей
		public List<(string WorkPiece, int Count)> WorkPieces { get; set; } = new();
	}
}
