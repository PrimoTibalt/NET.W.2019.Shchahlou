using System;
using System.Collections.Generic;

namespace DAI.Fake
{
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
