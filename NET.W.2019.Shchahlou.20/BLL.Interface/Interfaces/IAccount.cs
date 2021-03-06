﻿namespace BLL.Interface.Interfaces
{
    public interface IAccount
    {
        string Name { get; set; }

        long AccountNumber { get; }

        decimal Money { get; }

        double Balls { get; }

        void DepositeMoneyToBalls(decimal money);

        void WithdrawMoneyToBalls(decimal money);
    }
}
