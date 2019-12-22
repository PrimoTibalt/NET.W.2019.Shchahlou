using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class BaseAccount : Account
    {
        public const AccountType type = AccountType.Base;

        public BaseAccount(string name, long number) : base(name, number)
        {
            CostOfDeposite = 100;
            CostOfWithdraw = 20;
        }
    }
}
