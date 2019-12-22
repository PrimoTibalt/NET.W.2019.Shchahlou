using System;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public abstract class Account : IAccount
    {
        protected Func<decimal, double> depositeMoneyToBallsDelegate;

        protected Func<decimal, double> withdrawMoneyToBallsDelegate;

        protected string name;

        protected decimal money;

        protected double balls;

        protected int costOfDeposite;

        protected int costOfWithdraw;

        public Account(string name, long number)
        {
            this.name = name;
            this.AccountNumber = number;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Name of the account should be at least 2 symbols!");
                }
            }
        }

        public decimal Money { get; set; }

        public double Balls { get; }

        public long AccountNumber { get; }

        /// <summary>
        /// Add balls from money to deposite.
        /// </summary>
        /// <param name="money"></param>
        public virtual void DepositeMoneyToBalls(decimal money)
        {
            depositeMoneyToBallsDelegate += (cash) => (double)cash * costOfDeposite;
            if (costOfWithdraw > 0)
            {
                this.balls += depositeMoneyToBallsDelegate(money);
            }
            else
            {
                throw new ArgumentException("Didn't set value of CostOfDeposite.");
            }
        }

        /// <summary>
        /// Withdraw balls for withdraw money.
        /// </summary>
        /// <param name="money"></param>
        public virtual void WithdrawMoneyToBalls(decimal money)
        {
            withdrawMoneyToBallsDelegate += (cash) => (double)cash * costOfWithdraw;
            if ((this.balls - withdrawMoneyToBallsDelegate(money)) > 0)
            {
                this.balls -= withdrawMoneyToBallsDelegate(money);
            }
            else
            {
                this.balls = 0;
            }
        }
    }
}
