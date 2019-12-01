using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NET.W._2019.Shchahlou._8
{
    public class BankAccountService
    {
        public BankAccount CurrentAccount;
        public BallExchenger exchenger;
        public IAccountStorage storage;

        public void PutMoneyIntoTheAccount(decimal money)
        {
            CurrentAccount.Cash += money;
            switch(CurrentAccount.status)
            {
                case Status.Base:
                    exchenger.Increase(money, Status.Base);
                    break;
                case Status.Gold:
                    break;
                case Status.Platinum:
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void WithdrawFromTheAccount(decimal money)
        {
            CurrentAccount.Cash -= money;
            switch (CurrentAccount.status)
            {
                case Status.Base:
                    exchenger.Decrease(money, Status.Base);
                    break;
                case Status.Gold:
                    break;
                case Status.Platinum:
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void CreateNewAccount(string firstName, string lastName, decimal StartCash, Status stat)
        {
            Save(CurrentAccount);
            CurrentAccount = new BankAccount(CurrentAccount.id + 1, firstName, lastName, StartCash, stat);
        }

        private void Save(BankAccount currentAccount)
        {
            storage.Store(currentAccount);
        }

        public void CloseTheAccount()
        {
            CurrentAccount = null;
        }

        public void ChangeExchenger(BallExchenger type)
        {
            exchenger = type;
        }
    }
}
