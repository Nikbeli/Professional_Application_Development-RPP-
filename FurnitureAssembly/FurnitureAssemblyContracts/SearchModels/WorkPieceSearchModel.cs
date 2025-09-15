using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.SearchModels
{
    // Модель для поиска сущности "Компонент" (она же заготовка) 
    public class WorkPieceSearchModel
    {
        // Для поиска по идентификатору
        public int? Id { get; set; }

        // Для поиска по названию
        public string? WorkPieceName { get; set; }
    }
}

