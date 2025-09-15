using FurnitureAssemblyBusinessLogic.OfficePackage.HelperEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels
{
	// Информация п параграфу в pdf документе
	public class PdfParagraph
	{
		public string Text { get; set; } = string.Empty;

		public string Style { get; set; } = string.Empty;

		// Информация по выравниванию текста в параграфе
		public PdfParagraphAlignmentType ParagraphAlignment { get; set; }
	}
}
