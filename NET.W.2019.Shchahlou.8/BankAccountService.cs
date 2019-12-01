using System;

namespace NET.W._2019.Shchahlou._8
{
    public class BankAccountService
    {
        public BankAccount CurrentAccount;
        public BallExchenger Exchenger;
        public IAccountStorage Storage;

        public void PutMoneyIntoTheAccount(decimal money)
        {
            CurrentAccount.Cash += money;

            switch (CurrentAccount.Status)
            {
                case Status.Base:
                    Exchenger.Increase(money, Status.Base);
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
            switch (CurrentAccount.Status)
            {
                case Status.Base:
                    Exchenger.Decrease(money, Status.Base);
                    break;
                case Status.Gold:
                    break;
                case Status.Platinum:
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void CreateNewAccount(string firstName, string lastName, decimal startCash, Status stat)
        {
            Save(CurrentAccount);
            CurrentAccount = new BankAccount(CurrentAccount.Id + 1, firstName, lastName, startCash, stat);
        }

        public void CloseTheAccount()
        {
            CurrentAccount = null;
        }

        public void ChangeExchenger(BallExchenger type)
        {
            Exchenger = type;
        }

        private void Save(BankAccount currentAccount)
        {
            Storage.Store(currentAccount);
        }
    }
}
