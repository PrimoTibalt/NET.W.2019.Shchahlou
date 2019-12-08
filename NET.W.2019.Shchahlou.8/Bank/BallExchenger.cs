using System;

namespace NET.W._2019.Shchahlou._8
{
    public class BallExchenger
    {
        public virtual int Increase(decimal money, Status percent)
        {
            return (int)Math.Round(money * (int)percent);
        }

        public virtual int Decrease(decimal money, Status percent)
        {
            return (int)Math.Round((money - 10) * (int)percent);
        }
    }
}
