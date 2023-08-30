using LiteDB;

namespace LiteDbPlayground.DbModels;

public class Order : IOrder
{
    [BsonId]
    public int OderId { get; set; }
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }

    [BsonRef("customers")]
    public ICustomer? Customer { get; set; }
}