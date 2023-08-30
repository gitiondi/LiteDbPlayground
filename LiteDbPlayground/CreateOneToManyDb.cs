using LiteDB;
using LiteDbPlayground.DbModels;

namespace LiteDbPlayground
{
    public class CreateOneToManyDb
    {
        public static void Main()
        {
            const string dbFile = @"c:\data\litedb\OneToMany.db";
            if (File.Exists(dbFile))
            {
                File.Delete(dbFile);
            }
            using var db = new LiteDatabase(dbFile);

            var customer0 = new Customer
            {
                Name = "Muster0"
            };

            var customer1 = new Customer
            {
                Name = "Muster1"
            };

            var customer2 = new CustomerWithNumber()
            {
                CustomerNumber = 14280,
                Name = "Muster2"
            };

            var customer3 = new CustomerWithNumberAndBool()
            {
                CustomerNumber = 35419,
                CustomerIsVip = false,
                Name = "Muster3"
            };

            var customer4 = new IndependentCustomer()
            {
                Name = "Muster4",
                CustomerDescription = "Das isch nur en Tescht!"
            };

            var order0 = new Order { OrderNumber = 0, OrderDate = DateTime.Now, Customer = customer0 };
            var order1 = new Order { OrderNumber = 1, OrderDate = DateTime.Now, Customer = customer0 };
            var order2 = new Order { OrderNumber = 2, OrderDate = DateTime.Now, Customer = customer1 };
            var order3 = new Order { OrderNumber = 3, OrderDate = DateTime.Now, Customer = customer2 };
            var order4 = new Order { OrderNumber = 4, OrderDate = DateTime.Now, Customer = customer3 };
            var order5 = new Order { OrderNumber = 5, OrderDate = DateTime.Now, Customer = customer4 };

            var customers = db.GetCollection<ICustomer>("customers");
            var orders = db.GetCollection<IOrder>("orders");

            customers.Insert(customer0);
            customers.Insert(customer1);
            customers.Insert(customer2);
            customers.Insert(customer3);
            customers.Insert(customer4);

            orders.Insert(order0);
            orders.Insert(order1);
            orders.Insert(order2);
            orders.Insert(order3);
            orders.Insert(order4);
            orders.Insert(order5);
        }
    }
}