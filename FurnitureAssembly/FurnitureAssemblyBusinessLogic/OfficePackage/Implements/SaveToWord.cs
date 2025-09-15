using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using FurnitureAssemblyBusinessLogic.OfficePackage.HelperEnums;
using FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.OfficePackage.Implements
{
    // Реализация абстрактного класса сохранения в Word документ
    public class SaveToWord : AbstractSaveToWord
    {
        private WordprocessingDocument? _wordDocument;

        private Body? _docBody;

        // Получение типа выравнивания
        private static JustificationValues GetJustificationValues(WordJustificationType type)
        {
            // Выравнивание слева будет в том случае, если передаётся неизвестный тип выравнивания
            return type switch
            {
                WordJustificationType.Both => JustificationValues.Both,
                WordJustificationType.Center => JustificationValues.Center,
                _ => JustificationValues.Left,
            };
        }

        // Настройки страницы
        private static SectionProperties CreateSectionProperties()
        {
            var properties = new SectionProperties();

            // Прописываем портретную ориентацию
            var pageSize = new PageSize
            {
                Orient = PageOrientationValues.Portrait
            };

            properties.AppendChild(pageSize);

            return properties;
        }

        // Задание форматирования для абзаца
        private static ParagraphProperties? CreateParagraphProperties(WordTextProperties? paragraphProperties)
        {
            if (paragraphProperties == null)
            {
                return null;
            }

            var properties = new ParagraphProperties();

            // Вытаскиваем выравнивание текста
            properties.AppendChild(new Justification()
            {
                Val = GetJustificationValues(paragraphProperties.JustificationType)
            });

            properties.AppendChild(new SpacingBetweenLines
            {
                LineRule = LineSpacingRuleValues.Auto
            });

            properties.AppendChild(new Indentation());

            var paragraphMarkRunProperties = new ParagraphMarkRunProperties();

            if (!string.IsNullOrEmpty(paragraphProperties.Size))
            {
                paragraphMarkRunProperties.AppendChild(new FontSize { Val = paragraphProperties.Size });
            }

            properties.AppendChild(paragraphMarkRunProperties);

            return properties;
        }

        protected override void CreateWord(WordInfo info)
        {
            // Создаём документ Word
            _wordDocument = WordprocessingDocument.Create(info.FileName, WordprocessingDocumentType.Document);

            // Вытаскиваем главную часть из вордовского документа
            MainDocumentPart mainPart = _wordDocument.AddMainDocumentPart();

            mainPart.Document = new Document();

            // Генерируем тело основной части документа
            _docBody = mainPart.Document.AppendChild(new Body());
        }

        protected override void CreateParagraph(WordParagraph paragraph)
        {
            // Проверка на то, был ли вызван WordprocessingDocument.Create (создался ли документ) и есть ли вообще параграф для вставки
            if (_docBody == null || paragraph == null)
            {
                return;
            }

            var docParagraph = new Paragraph();

            // Добавляем свойства параграфа
            docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));

            // Вставляем блоки текста (их называют Run)
            foreach (var run in paragraph.Texts)
            {
                var docRun = new Run();
                var properties = new RunProperties();

                // Задание свойств текста - размер и жирность
                properties.AppendChild(new FontSize { Val = run.Item2.Size });

                if (run.Item2.Bold)
                {
                    properties.AppendChild(new Bold());
                }

                docRun.AppendChild(properties);

                docRun.AppendChild(new Text { Text = run.Item1, Space = SpaceProcessingModeValues.Preserve });

                docParagraph.AppendChild(docRun);
            }

            _docBody.AppendChild(docParagraph);
        }

        // Метод сохранения документа
        protected override void SaveWord(WordInfo info)
        {
            if (_docBody == null || _wordDocument == null)
            {
                return;
            }

            // Вставляем информацию по секциям (смотри, что является входным параметром)
            _docBody.AppendChild(CreateSectionProperties());

            // Сохраняем документ
            _wordDocument.MainDocumentPart!.Document.Save();

            _wordDocument.Dispose();
        }

        protected override void CreateTable(WordTable table)
        {
            if (_docBody == null || table == null)
            {
                return;
            }

            Table tab = new Table();

            TableProperties props = new TableProperties(
               new TableBorders(
                   new TopBorder
                   {
                       Val = new EnumValue<BorderValues>(BorderValues.Single),
                       Size = 12
                   },

                   new BottomBorder
                   {
                       Val = new EnumValue<BorderValues>(BorderValues.Single),
                       Size = 12
                   },

                   new LeftBorder
                   {
                       Val = new EnumValue<BorderValues>(BorderValues.Single),
                       Size = 12
                   },

                   new RightBorder
                   {
                       Val = new EnumValue<BorderValues>(BorderValues.Single),
                       Size = 12
                   },

                   new InsideHorizontalBorder
                   {
                       Val = new EnumValue<BorderValues>(BorderValues.Single),
                       Size = 12
                   },

                   new InsideVerticalBorder
                   {
                       Val = new EnumValue<BorderValues>(BorderValues.Single),
                       Size = 12
                   })
            );

            tab.AppendChild<TableProperties>(props);
            TableGrid tableGrid = new TableGrid();

            for (int i = 0; i < table.Headers.Count; i++)
            {
                tableGrid.AppendChild(new GridColumn());
            }

            tab.AppendChild(tableGrid);
            TableRow tableRow = new TableRow();

            foreach (var text in table.Headers)
            {
                tableRow.AppendChild(CreateTableCell(text));
            }

            tab.AppendChild(tableRow);

            int height = table.Texts.Count / table.Headers.Count;
            int width = table.Headers.Count;
            
            for (int i = 0; i < height; i++)
            {
                tableRow = new TableRow();

                for (int j = 0; j < width; j++)
                {
                    var element = table.Texts[i * table.Headers.Count + j];
                    tableRow.AppendChild(CreateTableCell(element));
                }

                tab.AppendChild(tableRow);
            }

            _docBody.AppendChild(tab);

        }

        private TableCell CreateTableCell(string element)
        {
            var tableParagraph = new Paragraph();

            var run = new Run();

            run.AppendChild(new Text 
            { 
                Text = element 
            });

            tableParagraph.AppendChild(run);
            var tableCell = new TableCell();
            tableCell.AppendChild(tableParagraph);

            return tableCell;
        }
    }
}
