using System.Collections.Generic;

namespace Domain.Contracts
{
    public interface Customer
    {
        int Id { get; set; }
        IEnumerable<Client> Clients { get; set; }
        string Name { get; set; }
        string Weakness { get; set; }
    }
}
