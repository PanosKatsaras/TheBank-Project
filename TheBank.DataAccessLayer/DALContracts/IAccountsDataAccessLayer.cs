using System;
using TheBank.Entities;
using System.Collections.Generic;

namespace TheBank.DataAccessLayer.DALContracts
{
    /// <summary>
    /// Interface that represents accounts data access layer
    /// </summary>
    public interface IAccountsDataAccessLayer
    {
        List<Account> GetAccounts();

        List<Account> GetAccountsByCondition(Predicate<Account> predicate);

        Guid NewAccount(Account account);

        bool UpdateAccount(Account account);

        bool DeleteAccount(Guid accountId);
    }
}
