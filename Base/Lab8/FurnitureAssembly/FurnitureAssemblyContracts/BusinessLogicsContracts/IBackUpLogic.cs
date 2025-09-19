using FurnitureAssemblyContracts.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BusinessLogicsContracts
{
    // Интерфейс создания бекапа
    public interface IBackUpLogic
    {
        // Путь и имя файла для архивации
        void CreateBackUp(BackUpSaveBindingModel model);
    }
}
