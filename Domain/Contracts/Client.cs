using System.Collections.Generic;

namespace Domain.Contracts
{
    public interface Client
    {
        string Name { get; set; }
        int Id { get; set; }
        string ClientOrderLogConnectionString { get; set; }
        string Moto { get; set; }
        IEnumerable<Customer> Customers { get; set; }
    }
}
