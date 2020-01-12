namespace NET.W._2019.Shchahlou._8.Bank
{
    using System;
    using NET.W._2019.Shchahlou._8.Bank.Interfaces;

    /// <summary>
    /// Represents Account for users of the bank.
    /// </summary>
    [Serializable]
    public class BankAccount : IBankAccount
    {
        private long id;

        private string firstName;

        private string lastName;

        private decimal cash;

        private Status statusAccount;

        private int bonusBalls;

        private bool freazed;

        /// <summary>
        /// Information about account.
        /// </summary>
        /// <param name="id">unique</param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="startCash"></param>
        /// <param name="stat"></param>
        public BankAccount(long id, string firstName, string lastName, decimal startCash, Status stat)
        {
            this.Id = id;

            this.FirstName = firstName;

            this.LastName = lastName;

            this.Cash = startCash;

            this.StatusAccount = stat;

            this.Freazed = false;

            this.BonusBalls = 0;
        }

        public long Id
        {
            get
            {
                return id;
            }

            private set
            {
                this.id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (!this.Freazed)
                {
                    this.firstName = value;
                }
                else
                {
                    this.AccountFreazed();
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (!this.Freazed)
                {
                    this.lastName = value;
                }
                else
                {
                    this.AccountFreazed();
                }
            }
        }

        public decimal Cash
        {
            get
            {
                return this.cash;
            }

            set
            {
                if (!this.Freazed)
                {
                    this.cash = value;
                }
                else
                {
                    this.AccountFreazed();
                }
            }
        }

        public Status StatusAccount
        {
            get
            {
                return this.statusAccount;
            }

            set
            {
                if (!this.Freazed)
                {
                    this.statusAccount = value;
                }
                else
                {
                    this.AccountFreazed();
                }
            }
        }

        public int BonusBalls
        {
            get
            {
                return this.bonusBalls;
            }

            set
            {
                if (!this.Freazed)
                {
                    this.bonusBalls = value;
                }
                else
                {
                    this.AccountFreazed();
                }
            }
        }

        public bool Freazed { get; set; }

        private void AccountFreazed()
        {
            Console.WriteLine("Account freazed, you cant change anything!");
        }
    }
}
