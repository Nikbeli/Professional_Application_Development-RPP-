using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Models
{
    public class FurnitureWorkPiece
    {
        public int Id { get; set; }

        [Required]
        public int FurnitureId { get; set; }

        [Required]
        public int WorkPieceId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual WorkPiece WorkPiece { get; set; } = new();

        public virtual Furniture Furniture { get; set; } = new();
    }
}
