using FurnitureAssemblyBusinessLogic.OfficePackage.HelperEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels
{
    // Информация по параметрам строк таблицы
    public class PdfRowParameters
    {
        // Набор текстов
        public List<string> Texts { get; set; } = new();

        // Стиль к текстам
        public string Style { get; set; } = string.Empty;

        // Как выравниваем
        public PdfParagraphAlignmentType ParagraphAlignment { get; set; }
    }
}
