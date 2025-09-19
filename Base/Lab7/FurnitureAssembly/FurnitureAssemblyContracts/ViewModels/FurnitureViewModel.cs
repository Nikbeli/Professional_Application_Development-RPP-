using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.ViewModels
{
    // Класс для отображения пользователю информации о продуктах (изделиях)
    public class FurnitureViewModel : IFurnitureModel
    {
        public int Id { get; set; }

        [DisplayName("Название изделия")]
        public string FurnitureName { get; set; } = string.Empty;

        [DisplayName("Цена")]
        public double Price { get; set; }

        public Dictionary<int, (IWorkPieceModel, int)> FurnitureWorkPieces { get; set; } = new();
    }
}