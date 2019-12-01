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
        public readonly long id;
        public string firstName;
        public string lastName;
        public decimal Cash;
        public Status status;
        public int BonusBalls;

        public BankAccount(long ID, string FirstName, string LastName, decimal StartCash, Status stat)
        {
            id = ID;
            firstName = FirstName;
            lastName = LastName;
            Cash = StartCash;
            status = stat;
        }

    }
}
