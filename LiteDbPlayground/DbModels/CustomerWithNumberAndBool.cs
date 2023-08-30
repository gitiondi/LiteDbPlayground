namespace LiteDbPlayground.DbModels
{
    public class CustomerWithNumberAndBool : CustomerWithNumber
    {
        public bool CustomerIsVip { get; set; }

        public override string Description()
        {
            var description = $"Type: {nameof(CustomerWithNumberAndBool)}\n";
            description += $"CustomerId: {CustomerId}\n";
            description += $"Name: {Name}\n";
            description += $"CustomerNumber: {CustomerNumber}\n";
            description += $"CustomerIsVip: {CustomerIsVip}\n";
            return description;
        }

    }
}
