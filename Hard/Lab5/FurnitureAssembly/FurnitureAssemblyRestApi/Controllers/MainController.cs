using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureAssemblyRestApi.Controllers
{
    // Контроллер с логикой по заказам и изделиям

    // Настройка контроллер для использования нескольких Post и Get запросов
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly ILogger _logger;

        private readonly IOrderLogic _order;

        private readonly IFurnitureLogic _furniture;

        public MainController(ILogger<MainController> logger, IOrderLogic order, IFurnitureLogic furniture)
        {
            _logger = logger;
            _order = order;
            _furniture = furniture;
        }

        [HttpGet]
        public List<FurnitureViewModel>? GetFurnitureList()
        {
            try
            {
                return _furniture.ReadList(null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка изделий");
                throw;
            }
        }

        [HttpGet]
        public FurnitureViewModel? GetFurniture(int furnitureId)
        {
            try
            {
                return _furniture.ReadElement(new FurnitureSearchModel
                {
                    Id = furnitureId
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения изделия по id={Id}", furnitureId);
                throw;
            }
        }

        [HttpGet]
        public List<OrderViewModel>? GetOrders(int clientId)
        {
            try
            {
                return _order.ReadList(new OrderSearchModel
                {
                    ClientId = clientId
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка заказов клиента id = {Id}", clientId);
                throw;
            }
        }

        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            try
            {
                _order.CreateOrder(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заказа");
                throw;
            }

        }
    }
}
