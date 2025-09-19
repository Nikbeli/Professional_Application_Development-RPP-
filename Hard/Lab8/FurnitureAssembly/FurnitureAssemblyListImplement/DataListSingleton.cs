using FurnitureAssemblyListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyListImplement
{
    // Класс для списков, в которых будет храниться информация при работе приложения
    public class DataListSingleton
    {
        private static DataListSingleton? _instance;

        // Список для хранения заготовок
        public List<WorkPiece> WorkPiece { get; set; }

        // Список для хранения изделий
        public List<Furniture> Furnitures { get; set; }

        // Список для хранения заказов
        public List<Order> Orders { get; set; }

        // Список для хранения Магазинов
        public List<Shop> Shops { get; set; }

        // Список для хранения Клиентов
        public List<Client> Clients { get; set; }

        // Список для хранения исполнителей
        public List<Implementer> Implementers { get; set; }

        // Список для хранения писем
        public List<MessageInfo> MessageInfos { get; set; }

        public DataListSingleton()
        {
            WorkPiece = new List<WorkPiece>();
            Furnitures = new List<Furniture>();
            Orders = new List<Order>();
            Shops = new List<Shop>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessageInfos = new List<MessageInfo>();
        }

        public static DataListSingleton GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DataListSingleton();
            }

            return _instance;
        }
    }
}