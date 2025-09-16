using FurnitureAssemblyClientApp.Models;
using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace FurnitureAssemblyClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Через API клиента Get-запросом получается список его собственных заказов
        public IActionResult Index()
        {
            if (APIClient.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={APIClient.Client.Id}"));
        }

        // Получение данных Get-ом
        [HttpGet]
        public IActionResult Privacy()
        {
            if (APIClient.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.Client);
        }

        // Изменение данных Post-ом
        [HttpPost]
        public void Privacy(string login, string password, string fio)
        {
            if (APIClient.Client == null)
            {
                throw new Exception("Вы как сюда попали? Суда вход только авторизованным. Кыш-кыш");
            }

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fio))
            {
                throw new Exception("Введите логин, пароль и ФИО");
            }

            APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
            {
                Id = APIClient.Client.Id,
                ClientFIO = fio,
                Email = login,
                Password = password
            });

            APIClient.Client.ClientFIO = fio;
            APIClient.Client.Email = login;
            APIClient.Client.Password = password;

            Response.Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        // Открытие Vieхи
        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        // Отправляем указанные данные на проверку
        [HttpPost]
        public void Enter(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Введите логин и пароль");
            }

            APIClient.Client = APIClient.GetRequest<ClientViewModel>($"api/client/login?login={login}&password={password}");

            if (APIClient.Client == null)
            {
                throw new Exception("Неверный логин/пароль");
            }

            Response.Redirect("Index");
        }

        // Открытие Vieхи
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Post-запрос по созданию нового пользователя
        [HttpPost]
        public void Register(string login, string password, string fio)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fio))
            {
                throw new Exception("Введите логин, пароль и ФИО");
            }

            APIClient.PostRequest("api/client/register", new ClientBindingModel
            {
                ClientFIO = fio,
                Email = login,
                Password = password
            });

            // Переход на вкладку "Enter", чтобы пользователь сразу смог зайти
            Response.Redirect("Enter");

            return;
        }

        // Создание заказа. Получаем и передаём список изделий во View
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Furnitures = APIClient.GetRequest<List<FurnitureViewModel>>("api/main/getfurniturelist");

            return View();
        }

        // Создание заказа Post-запросом
        [HttpPost]
        public void Create(int furniture, int count)
        {
            if (APIClient.Client == null)
            {
                throw new Exception("Вы как сюда попали? Сюда вход только авторизованным. Кыш-кыш");
            }

            if (count <= 0)
            {
                throw new Exception("Количество и сумма должны быть больше 0");
            }

            APIClient.PostRequest("api/main/createorder", new OrderBindingModel
            {
                ClientId = APIClient.Client.Id,
                FurnitureId = furniture,
                Count = count,
                Sum = Calc(count, furniture)
            });

            Response.Redirect("Index");
        }

        // Подсчёт стоимости заказа
        [HttpPost]
        public double Calc(int count, int furniture)
        {
            var furnitures = APIClient.GetRequest<FurnitureViewModel>($"api/main/getfurniture?furnitureId={furniture}");

            return count * (furnitures?.Price ?? 1);
        }

        // Для работы с письмами
        [HttpGet]
        public IActionResult Mails()
        {
            if (APIClient.Client == null)
            {
                return Redirect("~/Home/Enter");
            }

            return View(APIClient.GetRequest<List<MessageInfoViewModel>>($"api/client/getmessages?clientId={APIClient.Client.Id}"));
        }

        // Возвращает кортеж с таблицой в html, текущей страницей писем, выключать ли кнопку пред. страницы, выключать ли кнопку след. страницы
        [HttpGet]
        public Tuple<string?, string?, bool, bool>? SwitchPage(bool isNext)
        {
            if (isNext)
            {
                APIClient.CurrentPage++;
            }
            else
            {
                if (APIClient.CurrentPage == 1)
                {
                    return null;
                }

                APIClient.CurrentPage--;
            }

            var res = APIClient.GetRequest<List<MessageInfoViewModel>>($"api/client/getmessages?clientId={APIClient.Client!.Id}&page={APIClient.CurrentPage}");

            if (isNext && (res == null || res.Count == 0))
            {
                APIClient.CurrentPage--;

                return Tuple.Create<string?, string?, bool, bool>(null, null, APIClient.CurrentPage != 1, false);
            }

            StringBuilder htmlTable = new();

            foreach (var mail in res)
            {
                htmlTable.Append("<tr>" +
                                 $"<td>{mail.DateDelivery}</td>" +
                                 $"<td>{mail.Subject}</td>" +
                                 $"<td>{mail.Body}</td>" +
                                 "<td>" + (mail.IsRead ? "Прочитано" : "Непрочитано") + "</td>" +
                                 $"<td>{mail.Answer}</td>" +
                                 "</tr>");
            }

            return Tuple.Create<string?, string?, bool, bool>(htmlTable.ToString(), APIClient.CurrentPage.ToString(), APIClient.CurrentPage != 1, true);
        }
    }
}
