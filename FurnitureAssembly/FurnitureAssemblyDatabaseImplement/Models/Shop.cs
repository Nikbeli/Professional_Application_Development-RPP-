using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDatabaseImplement;
using FurnitureAssemblyDatabaseImplement.Models;
using FurnitureAssemblyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; set; }

        [Required]
        public string ShopName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public DateTime DateOpen { get; set; }

        [Required]
        public int MaxCountFurnitures { get; set; }

        private Dictionary<int, (IFurnitureModel, int)>? _shopFurnitures = null;

        [Required]
        public Dictionary<int, (IFurnitureModel, int)> ShopFurnitures
        {
            get
            {
                if (_shopFurnitures == null)
                {
                    _shopFurnitures = Furnitures.ToDictionary(recSI => recSI.FurnitureId, recSI => (recSI.Furniture as IFurnitureModel, recSI.Count));
                }
                return _shopFurnitures;
            }
        }

        [ForeignKey("ShopId")]
        public virtual List<ShopFurniture> Furnitures { get; set; } = new();

        public static Shop? Create(FurnitureAssemblyDatabase context, ShopBindingModel model)
        {
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpen = model.DateOpen,
                Furnitures = model.ShopFurnitures.Select(x => new ShopFurniture
                {
                    Furniture = context.Furnitures.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList(),
                MaxCountFurnitures = model.MaxCountFurnitures
            };
        }

        public void Update(ShopBindingModel model)
        {
            ShopName = model.ShopName;
            Address = model.Address;
            DateOpen = model.DateOpen;
            MaxCountFurnitures = model.MaxCountFurnitures;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            MaxCountFurnitures = MaxCountFurnitures,
            ShopFurnitures = ShopFurnitures
        };

        public void UpdateFurnitures(FurnitureAssemblyDatabase context, ShopBindingModel model)
        {
            var shopFurnitures = context.ShopFurnitures.Where(rec => rec.ShopId == model.Id).ToList();

            if (shopFurnitures != null && shopFurnitures.Count > 0)
            {   
                // Удалили те, которых нет в модели
                context.ShopFurnitures.RemoveRange(shopFurnitures
                    .Where(rec => !model.ShopFurnitures.ContainsKey(rec.FurnitureId)));
                context.SaveChanges();

                // Обновили количество у существующих записей
                foreach (var _shopFurnitures in shopFurnitures)
                {
                    _shopFurnitures.Count = model.ShopFurnitures[_shopFurnitures.FurnitureId].Item2;
                    model.ShopFurnitures.Remove(_shopFurnitures.FurnitureId);
                }

                context.SaveChanges();
            }

            var shop = context.Shops.First(x => x.Id == Id);

            foreach (var sm in model.ShopFurnitures)
            {
                context.ShopFurnitures.Add(new ShopFurniture
                {
                    Shop = shop,
                    Furniture = context.Furnitures.First(x => x.Id == sm.Key),
                    Count = sm.Value.Item2
                });

                context.SaveChanges();
            }

            _shopFurnitures = null;
        }
    }
}
