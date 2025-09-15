using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.SearchModels
{
    // Модель для поиска заготовки "Продукт" (она же изделие)
    public class FurnitureSearchModel
    {
        // Для поиска по идентификатору
        public int? Id { get; set; }

        // Для поиска по названию
        public string? FurnitureName { get; set; }
    }
}
