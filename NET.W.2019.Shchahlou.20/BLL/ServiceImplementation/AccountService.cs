namespace BLL.ServiceImplementation
{
    using System;
    using System.Collections.Generic;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
    using DAI.Interface.Interfaces;
    
    /// <summary>
    /// Class to service accounts and manage them in repository.
    /// </summary>
    public class AccountService : IAccountService
    {
        protected int accountsCount = 0;

        protected IRepository<Account> repos;

        /// <summary>
        /// Set repos equal to repository
        /// </summary>
        /// <param name="repository"></param>
        public AccountService(IRepository<Account> repository)
        {
            if (repository != null)
            {
                repos = repository;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Deletes account from repository if money > 0
        /// </summary>
        /// <param name="number"></param>
        public void CloseAccount(long number)
        {
            Account acc = FindAccount(number);
            if (acc.Money > 0)
            {
                repos.DeleteAccount(acc);
                accountsCount--;
            }
            else
            {
                throw new ArgumentException("No such account with number " + number);
            }
        }

        /// <summary>
        /// Get all created accounts, calls GetAccountsList.
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAllAccounts()
        {
            return repos.GetAccountsList();
        }

        /// <summary>
        /// Create new account in repository
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type">AccountType to choose what type of account we use</param>
        /// <param name="creator">Creates number for account</param>
        public void OpenAccount(string name, AccountType type, IAccountNumberCreateService creator)
        {
            Account acc;
            switch (type)
            { 
                case AccountType.Base: 
                    acc = new BaseAccount(name, creator.GetNextNumber(name));
                    break;
                case AccountType.Silver: 
                    acc = new SilverAccount(name, creator.GetNextNumber(name));
                    break;
                case AccountType.Gold: // Isn't implemented.
                    acc = new SilverAccount(name, creator.GetNextNumber(name));
                    break;
                default:
                    acc = new BaseAccount(name, creator.GetNextNumber(name));
                    break;
            }

            repos.AddToAccountList(acc);
            accountsCount++;
        }

        /// <summary>
        /// Withdraw money from account with so number 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="money"></param>
        public void WithdrawAccount(long number, decimal money)
        {
            IAccount acc = FindAccount(number);
            acc.WithdrawMoneyToBalls(money);
        }

        /// <summary>
        /// Deposit money to account with so number 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="money"></param>
        public void DepositAccount(long number, decimal money)
        {
            IAccount acc = FindAccount(number);
            acc.DepositeMoneyToBalls(money);
        }

        /// <summary>
        /// Search account by number in repository.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        protected Account FindAccount(long number)
        {
            Account account = null;
            foreach (Account acc in repos.GetAccountsList())
            {
                if (acc.AccountNumber == number)
                {
                    account = acc;
                    break;
                }
            }
            
            if (account == null)
            {
                throw new ArgumentException("Have no accounts with such number.");
            }

            return account;
        }
    }
}
