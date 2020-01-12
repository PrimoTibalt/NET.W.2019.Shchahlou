namespace NET.W._2019.Shchahlou._8.Bank.Interfaces
{
    /// <summary>
    /// To create different logic in giving balls from deposite and withdraw moeny and 
    /// </summary>
    public interface IBallExchenger
    {
        /// <summary>
        /// In case of deposite money to account.
        /// </summary>
        /// <param name="money"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int Increase(decimal money, Status status);

        /// <summary>
        /// In case of withdraw moeny from account.
        /// </summary>
        /// <param name="money"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int Decrease(decimal money, Status status);
    }
}
