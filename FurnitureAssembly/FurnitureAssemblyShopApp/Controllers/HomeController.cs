using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyShopApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FurnitureAssemblyShopApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!APIClient.isAuth)
            {
                return Redirect("~/Home/Enter");
            }

            return View(APIClient.GetRequest<List<ShopViewModel>>($"api/shop/getshoplist"));
        }

        public IActionResult Privacy()
        {
            if (!APIClient.isAuth)
            {
                return Redirect("~/Home/Enter");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string password)
        {
            if (!APIClient.Login(password))
            {
                throw new Exception("Wrong password");
            }

            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(string shopname, string address, DateTime DateOpening, int count)
        {
            if (!APIClient.isAuth)
            {
                throw new Exception("Как вы сюда попали? Сюда могут входить только избранные");
            }

            if (count <= 0)
            {
                throw new Exception("Максимальное количество товаров должно быть больше либо равно 0");
            }

            APIClient.PostRequest("api/shop/createshop", new ShopBindingModel
            {
                ShopName = shopname,
                MaxCountFurnitures = count,
                Address = address,
                DateOpen = DateOpening
            });

            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshoplist");
            return View();
        }

        [HttpPost]
        public void Delete(int shop)
        {
            if (!APIClient.isAuth)
            {
                throw new Exception("Как вы сюда попали? Сюда могут входить только авторизованные");
            }

            APIClient.PostRequest($"api/shop/deleteshop", new ShopBindingModel { Id = shop });

            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Update()
        {
            ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshoplist");
            return View();
        }

        [HttpPost]
        public void Update(int shop, string shopname, string address, DateTime DateOpening, int count)
        {
            if (!APIClient.isAuth)
            {
                throw new Exception("Как вы сюда попали? Сюда могут входить только избранные");
            }

            APIClient.PostRequest($"api/shop/updateshop", new ShopBindingModel
            {
                Id = shop,
                ShopName = shopname,
                Address = address,
                DateOpen = DateOpening,
                MaxCountFurnitures = count
            });

            Response.Redirect("Index");
        }

        public IActionResult Supply()
        {
            ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshoplist");
            ViewBag.Furnitures = APIClient.GetRequest<List<FurnitureViewModel>>("api/main/getfurniturelist");
            
            return View();
        }

        [HttpPost]
        public void Supply(int shopId, int furnitureId, int count)
        {
            if (!APIClient.isAuth)
            {
                throw new Exception("Как вы сюда попали? Сюда могут входить только авторизованные");
            }

            APIClient.PostRequest($"api/shop/supplyfurniturestoshop", (new ShopSearchModel { Id = shopId }, new FurnitureBindingModel { Id = furnitureId }, count));
            
            Response.Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
