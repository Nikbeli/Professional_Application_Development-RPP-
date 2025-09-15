using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureAssemblyRestApi.Controllers
{
    // Указание для контроллера, что Route будет строиться по названиям контроллера и метода (так как у нас два Post-метода)
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ILogger _logger;

        private readonly IClientLogic _logic;

        public ClientController(IClientLogic logic, ILogger<ClientController> logger)
        {
            _logic = logic;
            _logger = logger;
        }

        [HttpGet]
        public ClientViewModel? Login(string login, string password)
        {
            try
            {
                // Поиск записи по переданным логину и паролю
                return _logic.ReadElement(new ClientSearchModel
                {
                    Email = login,
                    Password = password
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка входа в систему");
                throw;
            }
        }

        [HttpPost]
        public void Register(ClientBindingModel model)
        {
            try
            {
                // Создание клиента
                _logic.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка регистрации");
                throw;
            }
        }

        [HttpPost]
        public void UpdateData(ClientBindingModel model)
        {
            try
            {
                // Изменение клиента
                _logic.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления данных");
                throw;
            }
        }
    }
}
