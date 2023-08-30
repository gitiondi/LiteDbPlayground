using LiteDB;

namespace LiteDbPlayground.DbModels
{
    public abstract class CustomerBase : ICustomer
    {
        [BsonId]
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public abstract string Description();
    }
}
