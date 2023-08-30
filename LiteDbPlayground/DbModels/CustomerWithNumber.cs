namespace LiteDbPlayground.DbModels;

public class CustomerWithNumber : Customer
{
    public int CustomerNumber { get; set; }

    public override string Description()
    {
        var description = $"Type: {nameof(CustomerWithNumber)}\n";
        description += $"CustomerId: {CustomerId}\n";
        description += $"Name: {Name}\n";
        description += $"CustomerNumber: {CustomerNumber}\n";
        return description;
    }
}