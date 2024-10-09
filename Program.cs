using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiService
{
    public class TaxiFacade
    {
        protected UklonService _uklon;
        protected BoltService _bolt;
        protected UberService _uber;

        public TaxiFacade(UklonService uklon, BoltService bolt, UberService uber)
        {
            this._uklon = uklon;
            this._bolt = bolt;
            this._uber = uber;
        }

        
        public void MakeOrder(string serviceType, string startAddress, string endAddress)
        {
            string result = "Ініцілізація таксі замовлення:\n";

            switch (serviceType.ToLower())
            {
                case "uklon":
                    result += _uklon.PlaceOrder(startAddress, endAddress);
                    break;

                case "bolt":
                    result += _bolt.PlaceOrder(startAddress, endAddress);
                    break;

                case "uber":
                    result += _uber.PlaceOrder(startAddress, endAddress, DateTime.Now);
                    break;

                default:
                    result += "Невідома служба таксі.";
                    break;
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
    public class UklonService
    {
        public string PlaceOrder(string startAddress, string endAddress)
        {
            return $"Uklon: Замовлення з {startAddress} до {endAddress}\n";
        }
    }

    public class BoltService
    {
         public string PlaceOrderStart(string startAddress)
         {
             return $"Bolt: Початок поїздки {startAddress}\n";
         }
         public string PlaceOrderEnd(string endAddress)
         {
             return $"Bolt: Кінець поїздки { endAddress }";
         }
    }

    public class UberService
    {
        public string PlaceOrder(string startAddress, string endAddress, DateTime? time)
        {
            if (time == null)
            {
                throw new Exception("Uber вимагає час замовлення.");
            }

            return $"Uber: Замовлення з {startAddress} до {endAddress} на {time.Value.ToString("HH:mm dd.MM.yyyy")}\n";
        }
    }

    class Client
    {
        public static void ClientCode(TaxiFacade facade)
        {
            facade.MakeOrder("uklon", "вул. Університетська 14", "пл. Народна 3");

            facade.MakeOrder("bolt", "вул. Університетська 14", "пл. Народна 3");

            facade.MakeOrder("uber", "вул. Університетська 14", "пл. Народна 3");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            UklonService uklon = new UklonService();
            BoltService bolt = new BoltService();
            UberService uber = new UberService();

            TaxiFacade facade = new TaxiFacade(uklon, bolt, uber);

            Client.ClientCode(facade);
        }
    }
}




