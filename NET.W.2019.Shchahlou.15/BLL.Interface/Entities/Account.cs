using System;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public abstract class Account : IAccount
    {
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length<2)
                {
                    throw new ArgumentException("Name of the account should be at least 2 symbols!");
                }
            }
        }

        public Account(string name, long number)
        {
            this.name = name;
            this.AccountNumber = number;
        }

        public decimal Money { get; set; }

        public double Balls { get; }

        public long AccountNumber { get; }

        public virtual void DepositeMoneyToBalls(decimal money)
        {
            DepositeMoneyToBallsDelegate += (cash) => (double)cash * CostOfDeposite;
            if (CostOfWithdraw > 0)
            {
                this.balls += DepositeMoneyToBallsDelegate(money);
            }
            else
            {
                throw new ArgumentException("Didn't set value of CostOfDeposite.");
            }
        }

        public virtual void WithdrawMoneyToBalls(decimal money)
        {
            WithdrawMoneyToBallsDelegate += (cash) => (double)cash * CostOfWithdraw;
            if ((this.balls - WithdrawMoneyToBallsDelegate(money)) > 0)
            {
                this.balls -= WithdrawMoneyToBallsDelegate(money);
            }
            else
            {
                this.balls = 0;
            }
        }

        protected Func<decimal, double> DepositeMoneyToBallsDelegate;

        protected Func<decimal, double> WithdrawMoneyToBallsDelegate;

        protected string name;

        protected decimal money;

        protected double balls;

        protected int CostOfDeposite;

        protected int CostOfWithdraw;
    }
}
