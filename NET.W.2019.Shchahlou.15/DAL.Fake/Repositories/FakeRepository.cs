using System;
using System.Collections.Generic;

namespace DAI.Fake
{
    public static class FakeRepository<T>
    {
        public static List<T> Repository = new List<T>();
    }
}
