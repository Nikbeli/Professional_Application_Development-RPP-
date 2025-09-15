using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Models
{
    public class WorkPiece : IWorkPieceModel
    {
        public int Id { get; private set; }

        [Required]
        public string WorkPieceName { get; private set; } = string.Empty;

        [Required]
        public double Cost { get; set; }

        // для реализации связи многие ко многим с изделиями
        [ForeignKey("WorkPieceId")]
        public virtual List<FurnitureWorkPiece> FurnitureWorkPieces { get; set; } = new();

        public static WorkPiece? Create(WorkPieceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new WorkPiece()
            {
                Id = model.Id,
                WorkPieceName = model.WorkPieceName,
                Cost = model.Cost
            };
        }

        public static WorkPiece Create(WorkPieceViewModel model)
        {
            return new WorkPiece
            {
                Id = model.Id,
                WorkPieceName = model.WorkPieceName,
                Cost = model.Cost
            };
        }

        public void Update(WorkPieceBindingModel model)
        {
            if (model == null)
            {
                return;
            }

            WorkPieceName = model.WorkPieceName;
            Cost = model.Cost;
        }

        public WorkPieceViewModel GetViewModel => new()
        {
            Id = Id,
            WorkPieceName = WorkPieceName,
            Cost = Cost
        };
    }
}
