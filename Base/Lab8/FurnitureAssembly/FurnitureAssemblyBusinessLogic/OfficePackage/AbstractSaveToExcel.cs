using FurnitureAssemblyBusinessLogic.OfficePackage.HelperEnums;
using FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToExcel
    {
        // Создание отчета. Описание методов ниже
        public void CreateReport(ExcelInfo info)
        {
            CreateExcel(info);

            InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "A",
                RowIndex = 1,
                Text = info.Title,
                StyleInfo = ExcelStyleInfoType.Title
            });

            MergeCells(new ExcelMergeParameters
            {
                CellFromName = "A1",
                CellToName = "C1"
            });

            uint rowIndex = 2;

            foreach (var fwp in info.FurnitureWorkPieces)
            {
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = fwp.FurnitureName,
                    StyleInfo = ExcelStyleInfoType.Text
                });

                rowIndex++;

                foreach (var (WorkPiece, Count) in fwp.WorkPieces)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = WorkPiece,
                        StyleInfo = ExcelStyleInfoType.TextWithBorder
                    });

                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = Count.ToString(),
                        StyleInfo = ExcelStyleInfoType.TextWithBorder
                    });

                    rowIndex++;
                }

                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = "Итого",
                    StyleInfo = ExcelStyleInfoType.Text
                });

                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "C",
                    RowIndex = rowIndex,
                    Text = fwp.TotalCount.ToString(),
                    StyleInfo = ExcelStyleInfoType.Text
                });

                rowIndex++;
            }

            SaveExcel(info);
        }

        // Создание Excel-файла
        protected abstract void CreateExcel(ExcelInfo info);

        // Добавляем новую ячейку в лист
        protected abstract void InsertCellInWorksheet(ExcelCellParameters excelParams);

        // Объединение ячеек
        protected abstract void MergeCells(ExcelMergeParameters excelParams);

        // Сохранение файла
        protected abstract void SaveExcel(ExcelInfo info);
    }
}
