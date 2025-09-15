using FurnitureAssemblyContracts.Attributes;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.ViewModels
{
	// Класс для отображения пользователю информации о продуктах (изделиях)
	public class FurnitureViewModel : IFurnitureModel
	{
		[Column(visible: false)]
		public int Id { get; set; }

		[Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
		public string FurnitureName { get; set; } = string.Empty;

		[Column(title: "Цена", width: 150)]
		public double Price { get; set; }

		[Column(visible: false)]
		public Dictionary<int, (IWorkPieceModel, int)> FurnitureWorkPieces { get; set; } = new();
	}
}
