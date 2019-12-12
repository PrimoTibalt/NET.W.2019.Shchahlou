namespace NET.W._2019.Shchahlou._12.Watches
{
    /// <summary>
    /// Class-observer.
    /// </summary>
    public class EasyWay
    {
        public bool Enterd { get; set; }

        public bool Relax { get; set; }

        public EasyWay()
        {
            Enterd = false;
            Relax = true;
        }

        public void StopRelaxation(object sender, BossState e)
        {
            Enterd = true;
            if (e.GoodMood)
            {
                Relax = true;
            }
            else
            {
                Relax = false;
            }
        }
    }
}
