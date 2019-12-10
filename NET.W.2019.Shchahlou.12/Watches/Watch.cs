using System;
using System.Threading;
using System.Timers;

namespace NET.W._2019.Shchahlou._12.Watches
{
    public class Watch
    {
        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);

        public event EventHandler<BossState> TimeHasCome;

        public DateTime BossTime { get; set; }

        private BossState bossState;

        protected Watches.EasyWay first;

        protected Watches.Coffee second;

        private static System.Timers.Timer aTimer;

        public Watch()
        {
            bossState = new BossState();
            Console.WriteLine("Set time, when boss will back!\nHH:mm:ss");
            for (; ;)
            {
                try
                {
                    BossTime = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    Console.WriteLine("You should write it correctly HH:mm:ss");
                    continue;
                }

                break;
            }
        }

        protected virtual void BossEnters(object sender, BossState e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("Didnt reach BossState.");
            }

            if (e.GoodMood)
            {
                Console.WriteLine("Hell Yeah! Boss in a good mood!\nI can make another cup of coffee!");
            }
            else
            {
                Console.WriteLine("Oh, no. Boss is sad. It means I'm also sad, lots of work comming...");
            }

            if (TimeHasCome != null)
            {
                TimeHasCome(sender, e);
            }
        }

        public void StartRelaxation()
        {
            first = new EasyWay();
            second = new Coffee();

            TimeHasCome += first.StopRelaxation;
            TimeHasCome += second.Drink;

            aTimer = new System.Timers.Timer(1000);

            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(CheckTime);
            aTimer.Enabled = true;
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }

        private void CheckTime(object sender, EventArgs e) 
        {
            if ((int)DateTime.Now.TimeOfDay.TotalSeconds == (int)BossTime.TimeOfDay.TotalSeconds)
            {
                BossEnters(this, bossState);
            }
            else
            {
                bossState.GoodMood = !bossState.GoodMood;
            }
        }
       
    }
}
