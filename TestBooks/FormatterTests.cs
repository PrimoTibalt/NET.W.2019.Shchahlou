using NUnit.Framework;
using System;
using NET.W._2019.Shchahlou._10;

namespace TestBooks
{
    [TestFixture]
    public class TestsFormatting
    {
        public TestsFormatting()
        {
            book = new Book()
            {
                Author = "Author",
                Name = "Name",
                Cost = 100,
                NumberOfPages = 826,
                Publisher = "Publisher",
                Year = 2012,
            };

            extension = new FormatExtension();
        }

        private Book book;

        private FormatExtension extension;

        [TestCase("A", null, ExpectedResult = "|||Author|||")]
        [TestCase("A," +
                  "N." +
                  "W." +
                  "I." +
                  "Y." +
                  "P," +
                  "C", null, ExpectedResult = "|||Author|||\n|||Name|||\n|||Publisher|||\n|||000-0000000000|||\n|||2012|||\n|||826|||\n|||100$|||")]
        [TestCase("", null, ExpectedResult = "|||Name|||")]
        public string Test_FormatExtension(string format, IFormatProvider formatProvider)
        {
            return book.ToString(format, null, extension);
        }
    }
}