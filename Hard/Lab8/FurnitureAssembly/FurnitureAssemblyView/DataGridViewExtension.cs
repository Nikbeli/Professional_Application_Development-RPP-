using FurnitureAssemblyContracts.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyView
{
    public static class DataGridViewExtension
    {
        public static void FillandConfigGrid<T>(this DataGridView grid, List<T>? data)
        {
            if (data == null)
            {
                return;
            }

            grid.DataSource = data;

            // Получаем тип
            var type = typeof(T);

            // Получаем свойства
            var properties = type.GetProperties();

            foreach (DataGridViewColumn column in grid.Columns)
            {
                var property = properties.FirstOrDefault(x => x.Name == column.Name);

                if (property == null)
                {
                    throw new InvalidOperationException($"В типе {type.Name} не найдено свойство с именем {column.Name}");
                }

                var attribute = property.GetCustomAttributes(typeof(ColumnAttribute), true)?.SingleOrDefault();

                if (attribute == null)
                {
                    throw new InvalidOperationException($"Не найден атрибут типа ColumnAttribute для свойства {property.Name}");
                }

                // Ищем нужный нам атрибут
                if (attribute is ColumnAttribute columnAttr)
                {
                    column.HeaderText = columnAttr.Title;
                    column.Visible = columnAttr.Visible;

                    if (columnAttr.IsUseAutoSize)
                    {
                        column.AutoSizeMode = (DataGridViewAutoSizeColumnMode)Enum.Parse(typeof(DataGridViewAutoSizeColumnMode),
                            columnAttr.GridViewAutoSize.ToString());
                    }
                    else
                    {
                        column.Width = columnAttr.Width;
                    }


                    column.DefaultCellStyle.Format = columnAttr.Format;
                }
            }
        }
    }
}
