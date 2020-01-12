namespace NET.W._2019.Shchahlou._8.Bank
{
    using System;
    using NET.W._2019.Shchahlou._8.Bank.Interfaces;

    /// <summary>
    /// Class to service BankAccount instances.
    /// </summary>
    public class BankAccountService
    {
        /// <summary>
        /// Create instance of BankAccountService.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="storage"></param>
        /// <param name="exchenger"></param>
        public BankAccountService(IBankAccount account, IAccountStorage storage, IBallExchenger exchenger)
        {
            this.CurrentAccount = account ?? throw new ArgumentNullException("account", "Try to set null as IBankAccount.");

            this.Storage = storage ?? throw new ArgumentNullException("storage", "Try to set null as IAccountStorage.");

            this.Exchenger = exchenger ?? throw new ArgumentNullException("exchenger", "Try to set null as IBallExchenger.");
        }

        /// <summary>
        /// Instance to work with.
        /// </summary>
        public IBankAccount CurrentAccount { get; set; }

        /// <summary>
        /// Storage to save BankAccount instances.
        /// </summary>
        public IAccountStorage Storage { get; set; }

        /// <summary>
        /// To get balls from money move.
        /// </summary>
        private IBallExchenger Exchenger { get; set; }

        /// <summary>
        /// Add money, add balls to CurrentAccount.
        /// </summary>
        /// <param name="money"></param>
        public void PutMoneyIntoTheAccount(decimal money)
        {
            this.CurrentAccount.Cash += money;
            this.CurrentAccount.BonusBalls += Exchenger.Increase(money, CurrentAccount.StatusAccount);
        }

        /// <summary>
        /// Withdraw money from, add balls to CurrentAccount.
        /// </summary>
        /// <param name="money"></param>
        public void WithdrawFromTheAccount(decimal money)
        {
            this.CurrentAccount.Cash -= money;
            this.CurrentAccount.BonusBalls += Exchenger.Decrease(money, CurrentAccount.StatusAccount);
        }

        /// <summary>
        /// Set new CurrentAccount and save old.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="startCash"></param>
        /// <param name="stat"></param>
        public void CreateNewAccount(string firstName, string lastName, decimal startCash, Status stat)
        {
            Save(CurrentAccount);
            this.CurrentAccount = new BankAccount(CurrentAccount.Id + 1, firstName, lastName, startCash, stat);
        }

        /// <summary>
        /// If CurrentAccount dont have credit(money in minus), sets account freaze.
        /// </summary>
        public void FreezeTheAccount()
        {
            if (CurrentAccount.Cash >= 0)
            {
                Save(CurrentAccount);
                this.CurrentAccount = null;
            }
            else
            {
                Console.WriteLine($"You cant freaze current account, he is in credit on {-this.CurrentAccount.Cash}$!");
            }
        }

        /// <summary>
        /// Set another class(inherit BallExchenger) to get balls from action with money.
        /// </summary>
        /// <param name="type"></param>
        public void ChangeExchenger(BallExchenger type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type", "Try to set null as BallExchenger.");
            }

            this.Exchenger = type;
        }

        /// <summary>
        /// Save account in storage.
        /// </summary>
        /// <param name="currentAccount"></param>
        private void Save(IBankAccount account)
        {
            this.Storage.Store(account);
        }
    }
}