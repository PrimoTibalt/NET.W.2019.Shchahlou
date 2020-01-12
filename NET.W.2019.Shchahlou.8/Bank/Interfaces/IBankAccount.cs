namespace NET.W._2019.Shchahlou._8.Bank.Interfaces
{
    public interface IBankAccount
    {
        public long Id { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Cash { get; set; }

        public Status StatusAccount { get; set; }

        public int BonusBalls { get; set; }
    }
}
