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
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel>? ReadList(MessageInfoSearchModel? model);

        MessageInfoViewModel? ReadElement(MessageInfoSearchModel model);

        bool Create(MessageInfoBindingModel model);

        bool Update(MessageInfoBindingModel model);
    }
}
