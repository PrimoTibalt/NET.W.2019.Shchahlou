﻿namespace ConsolePL
{
    using System;
    using System.Linq;
    using System.Data;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
    using DAL.Repositories;
    using DependencyResolver;
    using Ninject;
    using System.Data.Entity;

    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        public static void Main(string[] args)
        {
            IAccountService service = Resolver.Get<IAccountService>();
            IAccountNumberCreateService creator = Resolver.Get<IAccountNumberCreateService>();

            service.OpenAccount("Account owner 1", AccountType.Base, creator);
            service.OpenAccount("Account owner 2", AccountType.Base, creator);
            service.OpenAccount("Account owner 3", AccountType.Silver, creator);
            service.OpenAccount("Account owner 4", AccountType.Base, creator);

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

            foreach (var t in creditNumbers)
            {
                service.DepositAccount(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var t in creditNumbers)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item.Balls);
            }
           
            using (var db = new DatabaseRepository())
            {
                service.GetAllAccounts().ForEach((acc) => db.accounts.Add(acc));
                db.SaveChanges();
            }
            Console.WriteLine("Clear!");

            Console.ReadKey();
        }
    }
}
