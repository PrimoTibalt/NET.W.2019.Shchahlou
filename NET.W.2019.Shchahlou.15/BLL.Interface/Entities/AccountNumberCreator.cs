using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        public int GetNextNumber(string name)
        {
            return name.GetHashCode();
        }
    }
}
