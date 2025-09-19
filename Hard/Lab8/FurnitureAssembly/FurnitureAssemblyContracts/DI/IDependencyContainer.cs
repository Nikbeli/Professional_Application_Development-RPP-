using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.DI
{
    // Интерфейс установки зависимости между элементами
    public interface IDependencyContainer
    {
        //Регистрация логгера
        void AddLogging(Action<ILoggingBuilder> configure);

        //Добавление зависимости
        void RegisterType<T, U>(bool isSingle) where U : class, T where T : class;

        //Добавление зависимости
        void RegisterType<T>(bool isSingle) where T : class;

        //Получение класса со всеми зависимостями
        T Resolve<T>();
    }
}
