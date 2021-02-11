using System.Collections.Generic;

namespace Domain.Contracts
{
    public interface Order
    {
        Customer Customer { get; set; }
        IEnumerable<Product> Products { get; set; }
        double Total { get; set; }
        bool Fulfilled { get; set; }
    }
}
