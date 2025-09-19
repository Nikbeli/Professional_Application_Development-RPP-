using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyListImplement.Models
{
    // Класс реализующий интерфейс модели изделия
    public class Furniture : IFurnitureModel
    {
        // Методы set делаем приватным, чтобы исключить неразрешённые манипуляции
        public int Id { get; private set; }

        public string FurnitureName { get; private set; } = string.Empty;

        public double Price { get; private set; }

        public Dictionary<int, (IWorkPieceModel, int)> FurnitureWorkPieces { get; private set; } = new Dictionary<int, (IWorkPieceModel, int)>();

        // Метод для создания объекта от класса-компонента на основе класса-BindingModel
        public static Furniture? Create(FurnitureBindingModel? model)
        {
            if(model == null)
            {
                return null;
            }

            return new Furniture()
            {
                Id = model.Id,
                FurnitureName = model.FurnitureName,
                Price = model.Price,
                FurnitureWorkPieces = model.FurnitureWorkPieces
            };
        }

        // Метод изменения существующего объекта
        public void Update(FurnitureBindingModel? model)
        {
            if(model == null)
            {
                return;
            }

            FurnitureName = model.FurnitureName;
            Price = model.Price;
            FurnitureWorkPieces = model.FurnitureWorkPieces;
        }

        // Метод для создания объекта класса ViewModel на основе данных объекта класса-компонента
        public FurnitureViewModel GetViewModel => new()
        {
            Id = Id,
            FurnitureName = FurnitureName,
            Price = Price,
            FurnitureWorkPieces = FurnitureWorkPieces
        };
    }
}