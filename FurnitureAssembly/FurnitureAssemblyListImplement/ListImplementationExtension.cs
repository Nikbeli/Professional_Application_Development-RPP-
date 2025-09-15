using FurnitureAssemblyContracts.DI;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyListImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyListImplement
{
    public class ListImplementationExtension : IImplementationExtension
    {
        public int Priority => 0;

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
