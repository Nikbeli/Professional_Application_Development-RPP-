using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Models
{
    [DataContract]
    public class Furniture : IFurnitureModel
    {
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        public string FurnitureName { get; set; } = string.Empty;

        [Required]
        [DataMember]
        public double Price { get; set; }

        public Dictionary<int, (IWorkPieceModel, int)>? _furnitureWorkPieces = null;

        // Это поле не будет "мапиться" в бд
        [NotMapped]
        [DataMember]
        public Dictionary<int, (IWorkPieceModel, int)> FurnitureWorkPieces
        {
            get
            {
                if (_furnitureWorkPieces == null)
                {
                    _furnitureWorkPieces = WorkPieces
                        .ToDictionary(recPC => recPC.WorkPieceId, recPC => (recPC.WorkPiece as IWorkPieceModel, recPC.Count));
                }

                return _furnitureWorkPieces;
            }
        }

        // Для реализации связи многие ко многим с заготовками
        [ForeignKey("FurnitureId")]
        public virtual List<FurnitureWorkPiece> WorkPieces { get; set; } = new();

        [ForeignKey("FurnitureId")]
        public virtual List<Order> Orders { get; set; } = new();

        [ForeignKey("FurnitureId")]
        public virtual List<ShopFurniture> Shops { get; set; } = new();

        public static Furniture Create(FurnitureAssemblyDatabase context, FurnitureBindingModel model)
        {
            return new Furniture()
            {
                Id = model.Id,
                FurnitureName = model.FurnitureName,
                Price = model.Price,
                WorkPieces = model.FurnitureWorkPieces.Select(x => new FurnitureWorkPiece
                {
                    WorkPiece = context.WorkPieces.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList()
            };
        }

        public void Update(FurnitureBindingModel model)
        {
            FurnitureName = model.FurnitureName;
            Price = model.Price;
        }

        public FurnitureViewModel GetViewModel => new()
        {
            Id = Id,
            FurnitureName = FurnitureName,
            Price = Price,
            FurnitureWorkPieces = FurnitureWorkPieces
        };

        public void UpdateWorkPieces(FurnitureAssemblyDatabase context, FurnitureBindingModel model)
        {
            var furnitureWorkPieces = context.FurnitureWorkPieces
                .Where(rec => rec.FurnitureId == model.Id).ToList();

            if (furnitureWorkPieces != null && furnitureWorkPieces.Count > 0)
            {
                // Удалили те, которых нет в модели
                context.FurnitureWorkPieces.RemoveRange(furnitureWorkPieces
                    .Where(rec => !model.FurnitureWorkPieces.ContainsKey(rec.FurnitureId)));
                context.SaveChanges();

                // Обновили количество у существующих записей
                foreach (var updateFurniture in furnitureWorkPieces)
                {
                    updateFurniture.Count = model.FurnitureWorkPieces[updateFurniture.FurnitureId].Item2;
                    model.FurnitureWorkPieces.Remove(updateFurniture.FurnitureId);
                }

                context.SaveChanges();
            }

            var furniture = context.Furnitures.First(x => x.Id == Id);

            foreach (var fwp in model.FurnitureWorkPieces)
            {
                context.FurnitureWorkPieces.Add(new FurnitureWorkPiece
                {
                    Furniture = furniture,
                    WorkPiece = context.WorkPieces.First(x => x.Id == fwp.Key),
                    Count = fwp.Value.Item2
                });

                context.SaveChanges();
            }

            _furnitureWorkPieces = null;
        }
    }
}
