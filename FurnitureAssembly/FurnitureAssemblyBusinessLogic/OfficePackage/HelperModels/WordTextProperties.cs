using FurnitureAssemblyBusinessLogic.OfficePackage.HelperEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels
{
    // Модель свойств текста, которые нам нужны в Word документе
    public class WordTextProperties
    {
        // Размер текста
        public string Size { get; set; } = string.Empty;

        // Надо ли делать его жирным
        public bool Bold { get; set; }

        // Выравнивание
        public WordJustificationType JustificationType { get; set; }
    }
}
