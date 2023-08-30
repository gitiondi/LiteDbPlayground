using LiteDB;

namespace LiteDbPlayground.DbModels;

public interface IOrder
{
    [BsonId]
    int OderId { get; set; }

    [BsonRef("customers")]
    public ICustomer? Customer { get; set; }
}