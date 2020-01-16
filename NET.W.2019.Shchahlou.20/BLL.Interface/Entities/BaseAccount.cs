namespace BLL.Interface.Entities
{
    /// <summary>
    /// Minimal costOfDeposit
    /// Maximum costOfWithdraw
    /// </summary>
    public class BaseAccount : Account
    {
        public const AccountType TYPE = AccountType.Base;

        public BaseAccount(string name, long number) : base(name, number)
        {
            this.costOfDeposite = 100;
            this.costOfWithdraw = 20;
        }
    }
}
