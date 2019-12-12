using System;

namespace NET.W._2019.Shchahlou._12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("*****Test Book's Service*****");
            Console.WriteLine("1 - Create books!");
            Book first = new Book()
            {
                Author = "Rob Miles",
                Name = "C# Programming Yellow Book",
                Cost = int.MaxValue,
                NumberOfPages = 216,
                Publisher = "Hell University",
                Year = 2016,
            };
            Console.WriteLine("Create 1!");
            Book second = new Book()
            {
                Author = "Andrew Stellman, Jennifer Greene",
                Name = "Head First C#",
                Cost = 39M,
                NumberOfPages = 960,
                Publisher = "O'Reilly Media",
                Year = 2013,
            };
            second.ISBNSet("9780596514822");
            Console.WriteLine("Create 2!");
            Book thirdDel = new Book()
            {
                Author = "Joe Albahari",
                Name = "C# 7.0 in a Nutshell",
                Cost = 66.23M,
                NumberOfPages = 800,
                Publisher = "Альфа-книга",
                Year = 2015,
            };
            thirdDel.ISBNSet("9785990944619");

            Console.WriteLine("Create 3!");
            Book fourthAdd = new Book()
            {
                Author = "Jon Skeet",
                Name = "C# in Depth",
                Cost = 28.5M,
                NumberOfPages = 528,
                Publisher = "Manning Publications",
                Year = 2019,
            };
            fourthAdd.ISBNSet("978 - 1617294532");

            Console.WriteLine("Create 4!");
            Book fifth = new Book()
            {
                Author = "Jeffrey Richter",
                Name = "CLR via C#",
                Cost = 32.52M,
                NumberOfPages = 896,
                Publisher = "Microsoft Press",
                Year = 2012,
            };
            fifth.ISBNSet("978 - 0735667457");

            Console.WriteLine("Create 5!");
            Console.WriteLine("End of creation!\nLets create BookListService!");
            Book[] massiv = new Book[] { first, second, thirdDel, fifth };
            BookListService service = new BookListService(massiv);
            Console.WriteLine("Let's throw books in the local storage");
            service.UpdateStorage();
            Console.WriteLine("Let's add book in service!");
            service.AddBook(fourthAdd);
            Console.WriteLine("Let's update the local storage!");
            service.UpdateStorage();
            Console.WriteLine("Find right: " +
                (service.FindBookByTag("Author", "Joe Albahari")[0].ISBNGet() == thirdDel.ISBNGet()));
            Console.WriteLine("Let's sort our storage!");
            Console.WriteLine("Let's delete book from service!");
            service.RemoveBook(null);
            Console.WriteLine("Let's sort books by everything!");
            service.SortBooksByTag(new BookYearComparer<Book>());

            service.SortBooksByTag(new BookCostComparer<Book>());

            Watches.Watch watch = new Watches.Watch();
            watch.StartRelaxation();
        }
    }
}
