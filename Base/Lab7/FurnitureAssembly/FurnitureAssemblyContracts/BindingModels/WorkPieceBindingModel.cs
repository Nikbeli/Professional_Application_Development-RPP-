using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BindingModels
{
    // Реализация сущности "Компонент"
    public class WorkPieceBindingModel
    {
        public int Id { get; set; }

        public string WorkPieceName { get; set; } = string.Empty;

        public double Cost { get; set; }
    }
}
