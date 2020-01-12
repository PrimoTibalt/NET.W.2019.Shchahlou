namespace NET.W._2019.Shchahlou._10.Book.Extensions
{
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// If you want to specify formatting of the Book
    /// then inherit this class and use instance of your class
    /// as argument in string ToString(format, provider, FormatExtension formatting).
    /// Format - |||TEXT|||
    /// </summary>
    public class FormatExtension : IFormattable
    {
        private Book bk;

        public override string ToString()
        {
            return "Use ToString with 3 parameters";
        }

        /// <summary>
        /// Main method with logic of formatting.
        /// A - author
        /// N - name
        /// W - publisher
        /// I - ISBN
        /// Y - year
        /// P - number of pages
        /// C - cost
        /// </summary>
        /// <param name="format">Letters of the format</param>
        /// <param name="provider">Some Culture Information</param>
        /// <returns>Formated string</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (bk == null)
            {
                throw new NullReferenceException("Null in Book bk.");
            }

            if (string.IsNullOrWhiteSpace(format))
            {
                format = "N";
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            StringBuilder result = new StringBuilder();
            foreach (char f in format.ToUpperInvariant())
            {
                switch (f.ToString())
                {
                    case "A":
                        result.Append($"|||{bk.Author}|||");
                        break;
                    case "N":
                        result.Append($"|||{bk.Name}|||");
                        break;
                    case "W":
                        result.Append($"|||{bk.Publisher}|||");
                        break;
                    case "I":
                        result.Append($"|||{bk.ISBNGet()}|||");
                        break;
                    case "Y":
                        result.Append($"|||{bk.Year}|||");
                        break;
                    case "P":
                        result.Append($"|||{bk.NumberOfPages}|||");
                        break;
                    case "C":
                        result.Append($"|||{bk.Cost}$|||");
                        break;
                    default:
                        if (char.IsPunctuation(f))
                        {
                            result.Append("\n");
                        }
                        else
                        {
                            continue;
                        }

                        break;
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Sets field Book bk
        /// Calls main function string ToString(format, provider).
        /// </summary>
        /// <param name="book"></param>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(Book book, string format, IFormatProvider provider)
        {
            bk = book;
            return this.ToString(format, provider);
        }
    }
}
