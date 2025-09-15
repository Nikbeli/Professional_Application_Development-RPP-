using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.ViewModels
{
	// Класс для отображения информации об исполнителях
	public class ImplementerViewModel : IImplementerModel
	{
		public int Id { get; set; }

		[DisplayName("ФИО исполнителя")]
		public string ImplementerFIO { get; set; } = string.Empty;

		[DisplayName("Пароль")]
		public string Password { get; set; } = string.Empty;

		[DisplayName("Стаж")]
		public int WorkExperience { get; set; }

		[DisplayName("Квалификация")]
		public int Qualification { get; set; }
	}
}
