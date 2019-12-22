using System;
using System.Collections.Generic;
using DAI.Interface.Interfaces;

namespace DAI.Repositories
{
    public class AccountBinaryRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Fake Constructor, don't do anything
        /// </summary>
        /// <param name="name"></param>
        public AccountBinaryRepository(string name)
        {
            //Mabe there will be something
        }

        public List<T> GetAccountsList()
        {
            return Fake.FakeRepository<T>.Repository;
        }

        public void AddToAccountList(T account)
        {
            Fake.FakeRepository<T>.Repository.Add(account);
        }

        public void DeleteAccount(T account)
        {
            if (GetAccountsList().Contains(account))
            {
                Fake.FakeRepository<T>.Repository.Remove(account);
            }
            else
            {
                throw new ArgumentException("There is no suck account in repository.");
            }
        }
    }
}
