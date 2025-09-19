using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.ViewModels
{
    public class ReportShopFurnituresViewModel
    {
        public string ShopName { get; set; } = string.Empty;

        public int TotalCount { get; set; }

        public List<(string Furniture, int Count)> Furnitures { get; set; } = new();
    }
}
