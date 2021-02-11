namespace Domain.Contracts
{
    public interface Product
    {
        string Name { get; set; }
        string Description { get; set; }
        double Price { get; set; }
    }
}
