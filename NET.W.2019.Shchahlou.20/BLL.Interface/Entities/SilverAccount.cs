namespace BLL.Interface.Entities
{
    /// <summary>
    /// Middle costOfDeposit
    /// Middle costOfWithdraw
    /// </summary>
    public class SilverAccount : Account
    {
        public const AccountType TYPE = AccountType.Silver;

        public SilverAccount(string name, long number) : base(name, number)
        {
            this.costOfDeposite = 120;
            this.costOfWithdraw = 15;
        }
    }
}
