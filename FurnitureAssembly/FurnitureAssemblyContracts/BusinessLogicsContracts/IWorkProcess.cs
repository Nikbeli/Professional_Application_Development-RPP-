using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BusinessLogicsContracts
{
    // Интерфейс для класса, имитирующего работу
    public interface IWorkProcess
    {
        // Запуск работ
        void DoWork(IImplementerLogic implementerLogic, IOrderLogic orderLogic);
    }
}
