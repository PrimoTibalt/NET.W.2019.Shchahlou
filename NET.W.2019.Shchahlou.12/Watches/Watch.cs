using System;
using System.Timers;

namespace NET.W._2019.Shchahlou._12.Watches
{
    /// <summary>
    /// When we create instance of Watch, it requires to set Boss arriving time.
    /// After calling StartRelaxation starts countdown before BossTime
    /// </summary>
    public class Watch
    {
        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);

        public event EventHandler<BossState> TimeHasCome;

        public DateTime BossTime { get; set; }

        private BossState bossState;

        protected EasyWay first;

        protected Coffee second;

        private static Timer aTimer;

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

        /// <summary>
        /// Subscribe to TimeHasCome (Boss arriving time)
        /// </summary>
        /// <param name="handler">observer method</param>
        public void BecomeAnObserver(EventHandler<BossState> handler)
        {
            if(handler == null)
            {
                throw new ArgumentNullException("Send null as handler.");
            }

            TimeHasCome += handler;
        }

        /// <summary>
        /// Calls event TimeHasCome
        /// </summary>
        /// <param name="sender">This object</param>
        /// <param name="e">Current Boss state</param>
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

            TimeHasCome?.Invoke(sender, e);
        }

        /// <summary>
        /// Starts countdown before BossTime (when Boss arriving)
        /// </summary>
        public void StartRelaxation()
        {
            first = new EasyWay();
            second = new Coffee();

            TimeHasCome += first.StopRelaxation;
            TimeHasCome += second.Drink;

            aTimer = new Timer(1000);

            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(CheckTime);
            aTimer.Enabled = true;
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }

        /// <summary>
        /// If current time equivalet to BossTime, then we call BossEnters
        /// otherwise method sets current boss Mood to reverse of current
        /// </summary>
        /// <param name="sender">Current Watch instance</param>
        /// <param name="e"></param>
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
