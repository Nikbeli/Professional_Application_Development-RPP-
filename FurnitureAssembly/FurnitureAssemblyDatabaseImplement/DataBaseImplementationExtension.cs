using FurnitureAssemblyContracts.DI;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyDatabaseImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement
{
    public class DataBaseImplementationExtension : IImplementationExtension
    {
        public int Priority => 2;

        public void RegisterServices()
        {
            DependencyManager.Instance.RegisterType<IClientStorage, ClientStorage>();

            DependencyManager.Instance.RegisterType<IWorkPieceStorage, WorkPieceStorage>();

            DependencyManager.Instance.RegisterType<IImplementerStorage, ImplementerStorage>();

            DependencyManager.Instance.RegisterType<IMessageInfoStorage, MessageInfoStorage>();

            DependencyManager.Instance.RegisterType<IOrderStorage, OrderStorage>();

            DependencyManager.Instance.RegisterType<IFurnitureStorage, FurnitureStorage>();

            DependencyManager.Instance.RegisterType<IBackUpInfo, BackUpInfo>();
        }
    }
}
