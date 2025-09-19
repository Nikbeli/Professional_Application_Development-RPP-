using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BindingModels
{
    // Реализация сущности "Изделие"
    public class FurnitureBindingModel : IFurnitureModel
    {
        public int Id { get; set; }

        public string FurnitureName { get; set; } = string.Empty;

        public double Price {  get; set; }

        public Dictionary<int, (IWorkPieceModel, int)> FurnitureWorkPieces { get; set; } = new();
    }
}