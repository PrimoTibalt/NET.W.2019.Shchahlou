using System.Collections.Generic;

namespace DAI.Interface.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAccountsList();

        void AddToAccountList(T account);

        void DeleteAccount(T account);
    }
}
