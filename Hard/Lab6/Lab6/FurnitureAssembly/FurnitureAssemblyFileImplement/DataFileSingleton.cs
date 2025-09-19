using FurnitureAssemblyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FurnitureAssemblyFileImplement
{
    internal class DataFileSingleton
    {
        private static DataFileSingleton? instance;

        private readonly string WorkPieceFileName = "WorkPiece.xml";

        private readonly string OrderFileName = "Order.xml";

        private readonly string FurnitureFileName = "Furniture.xml";

        private readonly string ShopFileName = "Shop.xml";

        private readonly string ClientFileName = "Client.xml";

        private readonly string ImplementerFileName = "Implementer.xml";

        public List<WorkPiece> WorkPieces { get; private set; }

        public List<Order> Orders { get; private set; }

        public List<Furniture> Furnitures { get; private set; }

        public List<Shop> Shops { get; private set; }

        public List<Client> Clients { get; private set; }

        public List<Implementer> Implementers { get; private set; }

        public static DataFileSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataFileSingleton();
            }

            return instance;
        }

        public void SaveWorkPieces() => SaveData(WorkPieces, WorkPieceFileName, "WorkPieces", x => x.GetXElement);

        public void SaveFurnitures() => SaveData(Furnitures, FurnitureFileName, "Furnitures", x => x.GetXElement);

        public void SaveOrders() => SaveData(Orders, OrderFileName, "Orders", x => x.GetXElement);

        public void SaveShops() => SaveData(Shops, ShopFileName, "Shops", x => x.GetXElement);

        public void SaveClients() => SaveData(Clients, ClientFileName, "Clients", x => x.GetXElement);

        public void SaveImplementers() => SaveData(Orders, ImplementerFileName, "Implementers", x => x.GetXElement);

        private DataFileSingleton()
        {
            WorkPieces = LoadData(WorkPieceFileName, "WorkPiece", x => WorkPiece.Create(x)!)!;
            Furnitures = LoadData(FurnitureFileName, "Furniture", x => Furniture.Create(x)!)!;
            Orders = LoadData(OrderFileName, "Order", x => Order.Create(x)!)!;
            Shops = LoadData(ShopFileName, "Shop", x => Shop.Create(x)!)!;
            Implementers = LoadData(ImplementerFileName, "Impleneter", x => Implementer.Create(x)!)!;

            Clients = LoadData(ClientFileName, "Client", x => Client.Create(x)!)!;
        }

        private static List<T>? LoadData<T>(string filename, string xmlNodeName, Func<XElement, T> selectFunction)
        {
            if (File.Exists(filename))
            {
                return XDocument.Load(filename)?.Root?.Elements(xmlNodeName)?.Select(selectFunction)?.ToList();
            }

            return new List<T>();
        }

        private static void SaveData<T>(List<T> data, string filename, string xmlNodeName, Func<T, XElement> selectFunction)
        {
            if(data != null)
            {
                new XDocument(new XElement(xmlNodeName, data.Select(selectFunction).ToArray())).Save(filename);
            }
        }
    }
}