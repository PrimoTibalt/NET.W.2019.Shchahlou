namespace NET.W._2019.Shchahlou._8.Bank.Interfaces
{
    /// <summary>
    /// To save BankAccount in some storage.
    /// </summary>
    public interface IAccountStorage
    {
        /// <summary>
        /// Save one account.
        /// </summary>
        /// <param name="ba"></param>
        public void Store(BankAccount ba);
    }
}
