using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.StoragesContracts
{
	// Класс хранилища компонентов (заготовок)
	public interface IWorkPieceStorage
	{
		List<WorkPieceViewModel> GetFullList();

		List<WorkPieceViewModel> GetFilteredList(WorkPieceSearchModel model);

		WorkPieceViewModel? GetElement(WorkPieceSearchModel model);

		WorkPieceViewModel? Insert(WorkPieceBindingModel model);

		WorkPieceViewModel? Update(WorkPieceBindingModel model);

		WorkPieceViewModel? Delete(WorkPieceBindingModel model);
	}
}
