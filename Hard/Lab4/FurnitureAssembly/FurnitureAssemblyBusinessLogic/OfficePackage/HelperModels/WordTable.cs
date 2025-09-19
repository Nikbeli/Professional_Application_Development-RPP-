using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels
{
    public class WordTable
    {
        public List<string> Headers { get; set; } = new();

        public List<string> Texts { get; set; } = new();
    }
}
