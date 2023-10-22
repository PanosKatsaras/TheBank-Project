using System;

namespace TheBank.Entities.Contracts
{
    /// <summary>
    /// Represents Interface of account entity
    /// </summary>
    public interface IAccount
    {
        Guid AccountID { get; set; }
        long AccountCode { get; set; }
        DateTime AccountDate { get; set; }
        double Balance { get; set; }
        Customer CustomerAccount { get; set; }
    }
}
