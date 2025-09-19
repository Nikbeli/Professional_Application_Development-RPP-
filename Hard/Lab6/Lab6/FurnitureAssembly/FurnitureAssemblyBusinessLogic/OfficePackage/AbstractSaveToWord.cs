﻿using FurnitureAssemblyBusinessLogic.OfficePackage.HelperEnums;
using FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        // Метод создания документа
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);

            // Создание ряда абзацев
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            // Заполнение абзацев текстом
            foreach (var furniture in info.Furnitures)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (furniture.FurnitureName + " ", new WordTextProperties { Bold = true, Size = "24", }),
                    (furniture.Price.ToString(), new WordTextProperties { Size = "24" }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }

            SaveWord(info);
        }

        public void CreateTable(WordInfo info)
        {
            CreateWord(info);

            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24" }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            List<List<(string, WordTextProperties)>> rowList = new()
            {
                new()
                {
                    new("Название", new WordTextProperties { Bold = true, Size = "24" } ),
                    new("Адрес", new WordTextProperties { Bold = true, Size = "24" } ),
                    new("Дата открытия", new WordTextProperties { Bold = true, Size = "24" } )
                }
            };

            foreach (var shop in info.Shops)
            {
                List<(string, WordTextProperties)> cellList = new()
                {
                    new(shop.ShopName, new WordTextProperties { Size = "24" }),
                    new(shop.Address, new WordTextProperties { Size = "24" }),
                    new(shop.DateOpen.ToShortDateString(), new WordTextProperties { Size = "24"})
                };

                rowList.Add(cellList);
            }

            CreateTable(new WordParagraph
            {
                RowTexts = rowList,
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            SaveWord(info);
        }

        // Создание Doc-файла
        protected abstract void CreateWord(WordInfo info);

        // Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);

        // Создание таблицы
        protected abstract void CreateTable(WordParagraph paragraph);

        // Сохранение файла
        protected abstract void SaveWord(WordInfo info);
    }
}
