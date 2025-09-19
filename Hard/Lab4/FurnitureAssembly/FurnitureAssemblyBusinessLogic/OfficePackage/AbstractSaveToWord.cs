using FurnitureAssemblyBusinessLogic.OfficePackage.HelperEnums;
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

        public void CreateTableDoc(WordInfo wordInfo)
        {
            CreateWord(wordInfo);

            var list = new List<string>();

            foreach (var shop in wordInfo.Shops)
            {
                list.Add(shop.ShopName);
                list.Add(shop.Address);
                list.Add(shop.DateOpen.ToString());
            }

            var wordTable = new WordTable
            {
                Headers = new List<string> {
                    "Название",
                    "Адрес",
                    "Дата открытия"},
                Texts = list
            };

            CreateTable(wordTable);
            SaveWord(wordInfo);
        }

        // Создание Doc-файла
        protected abstract void CreateWord(WordInfo info);

        // Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);

        // Создание таблицы
        protected abstract void CreateTable(WordTable info);

        // Сохранение файла
        protected abstract void SaveWord(WordInfo info);
    }
}
