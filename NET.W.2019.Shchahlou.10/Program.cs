namespace NET.W._2019.Shchahlou._10
{
    using System;
    using System.Globalization;
    using NET.W._2019.Shchahlou._10.SortComparer;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("---------BubbleTesting---------");
            BubbleTesting();
            Console.WriteLine("---------BookTesting---------");
            BookTesting();
        }

        public static void BookTesting()
        {
            Book richter = new Book()
            {
                Author = "Jeffrey Richter",
                Name = "CLR via C#",
                Cost = 59.99M,
                NumberOfPages = 826,
                Publisher = "Microsoft Press",
                Year = 2012,
            };
            richter.ISBNSet("978-0-7356-6745-7");
            Console.WriteLine(richter.ToString("A, N"));
            Console.WriteLine(richter.ToString("A, n, w, y"));
            Console.WriteLine(richter.ToString("I, A, N, W, Y, p, C"));
            Console.WriteLine("The same on HollyDay!!!");
            Console.WriteLine(richter.ToString("A, N", CultureInfo.CurrentCulture, new FormatExtension()));
            Console.WriteLine();
            Console.WriteLine(richter.ToString("A, n, w, y", CultureInfo.CurrentCulture, new FormatExtension()));
            Console.WriteLine();
            Console.WriteLine(richter.ToString("I, A, N, W, Y, p, C", CultureInfo.CurrentCulture, new FormatExtension()));
        }

        public static void BubbleTesting()
        {
            BubbleSort sort = new BubbleSort();
            int[][] m = new int[5][]
            {
                new int[] { 10, 5, 15, 20 },
                new int[] { 0, 0, 0 },
                new int[] { int.MaxValue, int.MinValue },
                new int[] { -100, -2000, 100, 200 },
                new int[] { }
            };
            _ = sort.SortByComparer(new AscendingMaxElementValue(), m);
            foreach (var val in m)
            {
                foreach (int value in val)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
