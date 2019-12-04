using System;

namespace NET.W._2019.Shchahlou._8
{
    [Serializable]
    public class Book : IComparable
    {
        private string isbn;

        private string name;

        private string author;

        private short year;

        private string publisher;

        private int numberOfPages;

        private decimal cost;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Name");
                }
            }
        }

        public string Author 
        {
            get
            {
                return author;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    author = value;
                }
                else
                {
                    author = "Author(s) is(are) unknown.";
                }
            }
        }

        public short Year 
        {
            get
            {
                return year;
            }

            set
            {
                if (value >= 0 && value <= DateTime.Now.Year)
                {
                    year = value;
                }
                else
                {
                    throw new ArgumentException("Year");
                }
            }
        }

        public string Publisher 
        {
            get
            {
                return publisher;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    publisher = value;
                }
                else
                {
                    publisher = "Without publisher.";
                }
            }
        }

        public int NumberOfPages
        {
            get
            {
                return numberOfPages;
            }

            set
            {
                if (value > 0)
                {
                    numberOfPages = value;
                }
                else
                {
                    throw new ArgumentException("NumberOfPages");
                }
            }
        }

        public decimal Cost
        {
            get
            {
                return cost;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cost cant be less than 0.");
                }
                else
                {
                    cost = value;
                }
            }
        }

        public override string ToString()
        {
            return author + " " + name + " " + year.ToString();
        }

        public override int GetHashCode()
        {
            return isbn.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == this.GetHashCode();
        }

        public string ISBNGet()
        {
            return isbn;
        }

        public void ISBNSet(string value)
        {
            int sum = 0;
            int koef = 10;
            foreach (char ch in value)
            {
                if (!char.IsDigit(ch) && ch != '-')
                {
                    throw new ArgumentException("ISBN");
                }
                else
                {
                    sum += int.Parse(ch.ToString()) * (koef--);
                }
            }

            int lastIndex = int.Parse(value[value.Length - 1].ToString());
            if (11 - (sum % 11) == lastIndex)
            {
                isbn = value;
            }
            else
            {
                throw new ArgumentException("ISBN");
            }
        }

        int IComparable.CompareTo(object obj)
        {
            Book secondBook = obj as Book;
            if (secondBook != null)
            {
                return this.year.CompareTo(secondBook.year);
            }
            else
            {
                throw new ArgumentException("Not a Book object.");
            }
        }
    }
}
