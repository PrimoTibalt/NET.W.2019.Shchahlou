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
        public BankAccount(long id, string firstName, string lastName, decimal startCash, Status stat)
        {
            this.Id = id;

            this.FirstName = firstName;

            this.LastName = lastName;

            this.Cash = startCash;

            this.Status = stat;
        }

        public long Id { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Cash { get; set; }

        public Status Status { get; set; }

        public int BonusBalls { get; set; }
    }
}
