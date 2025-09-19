using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.SearchModels
{
    // Для поиска сущности "Заказ"
    public class OrderSearchModel
    {
        // для поиска по идентификатору
        public int? Id { get; set; }

        public int? ClientId { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
