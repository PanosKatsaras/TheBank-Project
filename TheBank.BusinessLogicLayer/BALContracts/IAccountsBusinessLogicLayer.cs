using System;
using System.Collections.Generic;
using TheBank.Entities;

namespace TheBank.BusinessLogicLayer.BALContracts
{
    /// <summary>
    /// Interface that represents business logic layer
    /// </summary>
    public interface IAccountsBusinessLogicLayer
    {
        List<Account> GetAccounts();

        List<Account> GetAccountsByCondition(Predicate<Account> predicate);

        Guid NewAccount(Account account);

        bool UpdateAccount(Account account);

        bool DeleteAccount(Guid accountID);
    }
}
