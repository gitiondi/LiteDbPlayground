namespace LiteDbPlayground.DbModels;

public class Customer : CustomerBase
{
    public override string Description()
    {
        var description = $"Type: {nameof(Customer)}\n";
        description += $"CustomerId: {CustomerId}\n";
        description += $"Name: {Name}\n";
        return description;
    }
}