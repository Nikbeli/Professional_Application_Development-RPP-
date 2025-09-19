using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDataModels.Models
{
    // Интерфейс, отвечающий за продукт
    public interface IFurnitureModel : IId
    {
        // наименование изделия 
        string FurnitureName { get; }

        // цена изделия 
        double Price { get; }

        // словарь, хранящий пары кол-во + компонент и его цена
        Dictionary<int, (IWorkPieceModel, int)> FurnitureWorkPieces { get; }
    }
}