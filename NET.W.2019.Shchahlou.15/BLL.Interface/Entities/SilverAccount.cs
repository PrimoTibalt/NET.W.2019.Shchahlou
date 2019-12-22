
namespace BLL.Interface.Entities
{
    public class SilverAccount : Account
    {
        public const AccountType type = AccountType.Base;

        public SilverAccount(string name, long number) : base(name, number)
        {
            CostOfDeposite = 120;
            CostOfWithdraw = 15;
        }
    }
}
