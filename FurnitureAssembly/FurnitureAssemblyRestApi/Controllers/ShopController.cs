using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureAssemblyRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController : Controller
    {
        private readonly ILogger _logger;

        private readonly IShopLogic _shop;

        public ShopController(ILogger<ShopController> logger, IShopLogic shopLogic)
        {
            _logger = logger;
            _shop = shopLogic;
        }

        [HttpGet]
        public List<ShopViewModel>? GetShopList()
        {
            try
            {
                List<ShopViewModel> shops = _shop.ReadList(null);
                for (int i = 0; i < shops.Count; i++)
                    shops[i].FurnitureCount = shops[i].ShopFurnitures.Values.ToList().Select(x => (x.Item1.FurnitureName, x.Item2).ToTuple()).ToList();
                return shops;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка магазинов");
                throw;
            }
        }

        [HttpGet]
        public ShopViewModel? GetShop(int shopId)
        {
            try
            {
                return _shop.ReadElement(new ShopSearchModel
                {
                    Id = shopId
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения магазина по id={Id}", shopId);
                throw;
            }
        }

        [HttpPost]
        public void CreateShop(ShopBindingModel model)
        {
            try
            {
                _shop.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания магазина");
                throw;
            }
        }

        [HttpPost]
        public void UpdateShop(ShopBindingModel model)
        {
            try
            {
                _shop.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления магазина");
                throw;
            }
        }

        [HttpPost]
        public void DeleteShop(ShopBindingModel model)
        {
            try
            {
                _shop.Delete(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления магазина");
                throw;
            }
        }
        [HttpPost]
        public void SupplyFurnituresToShop(Tuple<ShopSearchModel, FurnitureBindingModel, int> shop_furniture)
        {
            try
            {
                _shop.AddFurniture(shop_furniture.Item1, shop_furniture.Item2, shop_furniture.Item3);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка пополнения магазина");
                throw;
            }
        }
    }
}
