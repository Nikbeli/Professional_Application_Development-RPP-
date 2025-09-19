using FurnitureAssemblyContracts.Attributes;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.ViewModels
{
    // Класс для отображения пользователю данных о заготовке (заготовках)
    public class WorkPieceViewModel : IWorkPieceModel
    {
        [Column(visible: false)]
        public int Id { get; set; }

        [Column(title: "Название заготовки", width: 150)]
        public string WorkPieceName { get; set; } = string.Empty;

        [Column(title: "Цена", width: 150)]
        public double Cost { get; set; }
    }
}