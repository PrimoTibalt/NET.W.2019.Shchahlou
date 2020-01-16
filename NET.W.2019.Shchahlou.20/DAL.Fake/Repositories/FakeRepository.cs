namespace DAI.Fake
{
    using System;
    using System.Collections.Generic;

    public static class FakeRepository<T>
    {
        private static List<T> repository = new List<T>();

        public static List<T> Repository
        {
            get
            {
                return repository;
            }

            set
            {
                if (value != null)
                {
                    repository = value;
                }
            }
        }
    }
}
