using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._12.Watches
{
    public class Coffee
    {
        public string Cup;

        public Coffee()
        {
            Cup = "Full";
        }

        public void Drink(object sender, BossState e)
        {
            if (e.GoodMood)
            {
                Cup = "Full";
            }
            else
            {
                Cup = "Empty";
            }
        }
    }
}
