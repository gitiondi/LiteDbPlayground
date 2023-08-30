using LiteDB;

namespace LiteDbPlayground.DbModels;

public interface ICustomer
{
    [BsonId]
    int CustomerId { get; set; }
    string Name { get; set; }
}