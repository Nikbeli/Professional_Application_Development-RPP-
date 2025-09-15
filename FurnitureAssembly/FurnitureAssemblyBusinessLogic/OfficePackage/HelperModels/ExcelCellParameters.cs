using FurnitureAssemblyBusinessLogic.OfficePackage.HelperEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels
{
	// Информация по ячейке в таблице excel
	public class ExcelCellParameters
	{
		// Название колонки
		public string ColumnName { get; set; } = string.Empty;

		// Строка
		public uint RowIndex { get; set; }

		// Тект в ячейке
		public string Text { get; set; } = string.Empty;

		// Геттер для того, чтобы не искать каждый раз
		public string CellReference => $"{ColumnName}{RowIndex}";

		// В каком стиле выводить информацию
		public ExcelStyleInfoType StyleInfo { get; set; }
	}
}
