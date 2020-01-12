namespace NET.W._2019.Shchahlou._10.Book.Extensions
{
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Extension class for users formatting.
    /// </summary>
    public static class BookExtension
    {
        /// <summary>
        /// Custom formatting of description of the Book.
        /// </summary>
        /// <param name="bk">The Book, information about</param>
        /// <param name="format">Letters of the format</param>
        /// <param name="provider">Some Culture Information</param>
        /// <param name="formatting">Custom class, if null -> uses standart format</param>
        /// <returns></returns>
        public static string ToString(this Book bk, string format, IFormatProvider provider, FormatExtension formatting)
        {
            if (formatting != null)
            {
                return formatting.ToString(bk, format, provider);
            }
            else
            {
                return bk.ToString(format);
            }
        }

        /// <summary>
        /// A - author
        /// N - name
        /// W - publisher
        /// I - ISBN
        /// Y - year
        /// P - number of pages
        /// C - cost
        /// </summary>
        /// <param name="format">Combination of format letters</param>
        /// <returns>Formatted information about book</returns>
        public static string ToString(this Book bk, string format)
        {
            return bk.ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Calls string ToString(format: "N", provider: CultureInfo.CurrentCulture)
        /// </summary>
        /// <returns></returns>
        public static string ToString(this Book bk)
        {
            return bk.ToString("N", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// A - author
        /// N - name
        /// W - publisher
        /// I - ISBN
        /// Y - year
        /// P - number of pages
        /// C - cost
        /// </summary>
        /// <param name="format">Combination of format letters</param>
        /// <param name="provider">CultureInformation</param>
        /// <returns>Formatted information about book</returns>
        public static string ToString(this Book bk, string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
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
                switch (f.ToString(provider))
                {
                    case "A":
                        result.Append($"{bk.Author}");
                        break;
                    case "N":
                        result.Append($"{bk.Name}");
                        break;
                    case "W":
                        result.Append($"\"{bk.Publisher}\"");
                        break;
                    case "I":
                        result.Append($"ISBN 13: {bk.ISBNGet()}");
                        break;
                    case "Y":
                        result.Append($"{bk.Year}");
                        break;
                    case "P":
                        result.Append($"P. {bk.NumberOfPages}.");
                        break;
                    case "C":
                        result.Append($"{bk.Cost}$");
                        break;
                    default:
                        result.Append(f);
                        break;
                }
            }

            return result.ToString();
        }
    }
}

