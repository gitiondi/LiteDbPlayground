using LiteDB;

namespace LiteDbPlayground
{

    public class BasicCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] Phones { get; set; }
        public bool IsActive { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            // Open database (or create if doesn't exist)
            using var db = new LiteDatabase(@"RicosLiteDb.db");
            // Get customer collection
            var col = db.GetCollection<BasicCustomer>("customers");

            // Create your new customer instance
            var customer = new BasicCustomer
            {
                Name = "John Doe",
                Phones = new string[] { "8000-0000", "9000-0000" },
                Age = 39,
                IsActive = true
            };

            // Create unique index in Name field
            col.EnsureIndex(x => x.Name, true);

            // Insert new customer document (Id will be auto-incremented)
            col.Insert(customer);   

            // Update a document inside a collection
            customer.Name = "Joana Doe";

            col.Update(customer);

            // Use LINQ to query documents (with no index)
            var results = col.Find(x => x.Age > 20);

            //-----

            // Untyped collection (T is BsonDocument)
            // Get collection instance
            var col2 = db.GetCollection("customer2");

            // Insert document to collection - if collection does not exist, it is created
            col2.Insert(new BsonDocument { ["_id"] = 1, ["Name"] = "John Doe" });
            col2.Insert(new BsonDocument { ["_id"] = 2, ["Name"] = "Hans Zimmer", ["Birth"] = DateTime.Now });

            // Create an index over the Field name (if it doesn't exist)
            col2.EnsureIndex("Name");

            // Now, search for your document
            var customer2 = col2.FindOne("$.Name = 'john doe'");
        }
    }
}