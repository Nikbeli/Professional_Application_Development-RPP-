using FurnitureAssemblyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels
{
    // Общая информация по документу
    public class WordInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        //список заготовок для вывода и сохранения
        public List<FurnitureViewModel> Furnitures { get; set; } = new();
    }
}
