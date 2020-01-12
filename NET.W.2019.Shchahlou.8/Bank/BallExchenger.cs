namespace NET.W._2019.Shchahlou._8.Bank
{
    using System;
    using NET.W._2019.Shchahlou._8.Bank.Interfaces;

    /// <summary>
    /// Support class for BankAccountService to get balls from money exchenging.
    /// </summary>
    public class BallExchenger : IBallExchenger
    {
        /// <summary>
        /// If we deposite money to bank.
        /// </summary>
        /// <param name="money"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        public virtual int Increase(decimal money, Status percent)
        {
            return (int)Math.Round(money * (int)percent);
        }

        /// <summary>
        /// If we withdraw money from bank.
        /// </summary>
        /// <param name="money"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        public virtual int Decrease(decimal money, Status percent)
        {
            return (int)Math.Round((money - 10) * (int)percent);
        }
    }
}
