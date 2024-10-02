using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            TaxiFacade facade = new TaxiFacade();

            string startAddress = "вул. Університетська 14";
            string endAddress = "пл. Народна 3";
            string time = "9:30 21.09.2022";

            facade.OrderUklon(startAddress, endAddress);
            facade.OrderBolt(startAddress, endAddress);
            facade.OrderUber(startAddress, endAddress, time);

            Console.ReadKey();
        }
    }
    public class Uklon
    {
        public void MakeOrder(string endAddress, string startAddress)
        {
            Console.WriteLine($" Замовлення з {startAddress} до {endAddress}");
        }
    }

    public class Bolt
    {
        public void SetStart(string startAddress)
        {
            Console.WriteLine($"Початок поїздки з {startAddress}");
        }

        public void SetEnd(string endAddress)
        {
            Console.WriteLine($"Кінець поїздки в {endAddress}");
        }
    }

    public class Uber
    {
        public void BookRide(string startAddress, string endAddress, string time)
        {
            Console.WriteLine($"Замовлення на поїздку з {startAddress} до {endAddress} о {time}");
        }
    }

    public class TaxiFacade
    {
        private Uklon uklon;
        private Bolt bolt;
        private Uber uber;

        public TaxiFacade()
        {
            uklon = new Uklon();
            bolt = new Bolt();
            uber = new Uber();
        }

        public void OrderUklon(string startAddress, string endAddress)
        {
            Console.WriteLine("\nЗамовляємо Uklon:");
            uklon.MakeOrder(endAddress, startAddress);
        }

        public void OrderBolt(string startAddress, string endAddress)
        {
            Console.WriteLine("\nЗамовляємо Bolt:");
            bolt.SetStart(startAddress);
            bolt.SetEnd(endAddress);
        }

        public void OrderUber(string startAddress, string endAddress, string time)
        {
            Console.WriteLine("\nЗамовляємо Uber:");
            uber.BookRide(startAddress, endAddress, time);
            Console.ReadLine();
        }

    }

}


