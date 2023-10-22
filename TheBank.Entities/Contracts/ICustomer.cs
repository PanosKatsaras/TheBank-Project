using System;

namespace TheBank.Entities.Contracts
{
    /// <summary>
    /// Represents interface of customer entity
    /// </summary>
    public interface ICustomer
    {
        Guid CustomerID { get; set; }
        long CustomerCode { get; set; }
        string CustomerFullName { get; set; }
        string CustomerAdress { get; set; }
        string CustomerCity { get; set; }
        string CustomerCountry { get; set; }
        string CustomerMobile { get; set; }
        string CustomerEmail { get; set; }

    }
}
