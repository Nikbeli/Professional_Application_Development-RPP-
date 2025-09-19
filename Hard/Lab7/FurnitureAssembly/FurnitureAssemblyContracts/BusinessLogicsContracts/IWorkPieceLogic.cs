using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BusinessLogicsContracts
{
    // Бизнес-логика для компонентов
    public interface IWorkPieceLogic
    {
        List<WorkPieceViewModel>? ReadList(WorkPieceSearchModel? model);

        WorkPieceViewModel? ReadElement(WorkPieceSearchModel model);

        bool Create(WorkPieceBindingModel model);

        bool Update(WorkPieceBindingModel model);

        bool Delete(WorkPieceBindingModel model);
    }
}