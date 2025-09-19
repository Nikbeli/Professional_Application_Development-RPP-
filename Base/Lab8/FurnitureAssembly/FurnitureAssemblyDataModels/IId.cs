using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDataModels
{
    // Интерфейс, отвечающий за id у компонентов, продуктов и чеков
    public interface IId
    {
        int Id { get; }
    }
}