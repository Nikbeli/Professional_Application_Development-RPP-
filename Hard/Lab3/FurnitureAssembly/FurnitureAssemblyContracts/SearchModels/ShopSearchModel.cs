using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.SearchModels
{
    // Для поиска сущности "Магазин"
    public class ShopSearchModel
    {
        // Для поиска по идентификатору
        public int? Id { get; set; }

        // Для поиска по названию
        public string? ShopName { get; set; }
    }
}