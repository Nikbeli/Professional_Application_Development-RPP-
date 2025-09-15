using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.ViewModels
{
	// Класс для отображения пользователю данных о заготовке (заготовках)
	public class WorkPieceViewModel : IWorkPieceModel
	{
		public int Id { get; set; }

		[DisplayName("Название заготовки")]
		public string WorkPieceName { get; set; } = string.Empty;

		[DisplayName("Цена")]
		public double Cost { get; set; }
	}
}
