using LiteDB;
using LiteDbPlayground.DbModels;
using System.Security.Cryptography;

namespace LiteDbPlayground
{
    public class QueryOneToManyDb
    {
        public static void Main()
        {
            // query customers
            using var db = new LiteDatabase(@"c:\data\litedb\OneToMany.db");

            var customers = db.GetCollection<ICustomer>("customers").FindAll();
            foreach (var customer in customers)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine((customer as CustomerBase)?.Description());
                Console.WriteLine("-----------------");
            }

            // query orders
            var orders = db.GetCollection<IOrder>("orders").Include(x => x.Customer).FindAll();
            foreach (var order in orders)
            {
                var ord = order as Order;
                var cus = ord.Customer as CustomerBase;

                Console.WriteLine("********************");
                Console.WriteLine($"OderId: {ord.OderId} OrderNumber: {ord.OrderNumber}");
                Console.WriteLine(cus?.Description());
                Console.WriteLine("********************");
            }

            // query customer for a specific order
            var ordersCustomer = db.GetCollection<Order>("orders").Include(x => x.Customer).Find(x => x.OrderNumber == 1).FirstOrDefault()?.Customer;
            Console.WriteLine();
            Console.WriteLine("query customer for a specific order");
            Console.WriteLine("********************");
            Console.WriteLine((ordersCustomer as CustomerBase)?.Description());
            Console.WriteLine("********************");
        }
    }
}