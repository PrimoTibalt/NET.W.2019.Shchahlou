using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Have base methods for every AccountService-
    /// Open one account
    /// Get list of accounts in service
    /// Deposit money to some account
    /// Withdraw money from some account
    /// </summary>
    public interface IAccountService
    {
        void OpenAccount(string name, AccountType type, IAccountNumberCreateService creator);

        List<Account> GetAllAccounts();

        void DepositAccount(long acc, decimal money);

        void WithdrawAccount(long acc, decimal money);

        void CloseAccount(long acc);
    }
}
