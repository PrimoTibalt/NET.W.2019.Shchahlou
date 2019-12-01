using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NET.W._2019.Shchahlou._8
{
    public class BankAccountService
    {
        public BankAccount CurrentAccount;


        public void PutMoneyIntoTheAccount(decimal money)
        {
            CurrentAccount.Cash += money;
            switch(CurrentAccount.status)
            {
                case Status.Base:

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
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream(@"BankAccounts.bin", FileMode.Create))
            {
                using (BinaryWriter writter = new BinaryWriter(file))
                {
                    binFormatter.Serialize(file, currentAccount);
                }
            }
        }

        public void CloseTheAccount()
        {
            CurrentAccount = null;
        }
    }
}
