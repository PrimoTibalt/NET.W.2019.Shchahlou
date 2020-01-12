namespace DAI.Interface.Interfaces
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        List<T> GetAccountsList();

        void AddToAccountList(T account);

        void DeleteAccount(T account);
    }
}
