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

        // для поиска по клиенту
        public int? ClientId { get; set; }

        // Два поля для возможности производить выборку
        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set;}
    }
}
