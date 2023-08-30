namespace LiteDbPlayground.DbModels
{
    public class IndependentCustomer : CustomerBase
    {
        public string CustomerDescription { get; set; }
        public override string Description()
        {
            var description = $"Type: {nameof(IndependentCustomer)}\n";
            description += $"CustomerId: {CustomerId}\n";
            description += $"Name: {Name}\n";
            description += $"CustomerDescription: {CustomerDescription}\n";
            return description;
        }
    }
}
