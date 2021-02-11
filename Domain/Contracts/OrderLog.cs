using System;

namespace Domain.Contracts
{
    public interface OrderLog
    {
        int ClientId { get; set; }
        int CustomerId { get; set; }
        int OrderId { get; set; }
        DateTime FulfillmentDate { get; set; } 
    }
}
