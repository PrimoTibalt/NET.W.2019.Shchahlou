using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._8
{
    public enum Status
    {
        Base,
        Gold,
        Platinum,
    }

    [Serializable]
    public class BankAccount
    {
        public readonly long Id;
        public string FirstName;
        public string LastName;
        public decimal Cash;
        public Status Status;
        public int BonusBalls;

        public BankAccount(long id, string firstName, string lastName, decimal startCash, Status stat)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Cash = startCash;
            this.Status = stat;
        }
    }
}
