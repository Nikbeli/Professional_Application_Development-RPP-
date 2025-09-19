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
    // Класс для хранилища исполнителей
    public interface IImplementerStorage
    {
        List<ImplementerViewModel> GetFullList();

        List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model);

        ImplementerViewModel? GetElement(ImplementerSearchModel model);

        ImplementerViewModel? Insert(ImplementerBindingModel model);

        ImplementerViewModel? Update(ImplementerBindingModel model);

        ImplementerViewModel? Delete(ImplementerBindingModel model);
    }
}
