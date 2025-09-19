using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.StoragesContracts
{
    // Интерфейс получения данных по всем сущностям
    public interface IBackUpInfo
    {
        // Метод получения данных по всем сущностям
        List<T>? GetList<T>() where T : class, new();

        Type? GetTypeByModelInterface(string modelInterfaceName);
    }
}
