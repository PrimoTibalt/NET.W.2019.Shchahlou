using System;
using System.Collections.Generic;

namespace NET.W._2019.Shchahlou._8
{
    public class BookListService
    {
        private List<Book> myCollection;
        private bool IsSorted = false;
        private Dictionary<string, Book> isbnBook = new Dictionary<string, Book>();
        private List<Book> booksToRemove;
        private List<Book> booksToAdd;
        private BookListStorage storage;

        public BookListService(params Book[] books)
        {
            myCollection = new List<Book>(books);
            booksToAdd = new List<Book>(books);
            booksToRemove = new List<Book>();
            storage = new BookListStorage(null);
        }

        private bool HaveBookInCol(Book newBook)
        {
            return isbnBook.ContainsKey(newBook.ISBNGet());
        }

        private void RemoveFromCollections(Book toRemove)
        {
            myCollection.Remove(toRemove);
            booksToAdd.Remove(toRemove);
            isbnBook.Remove(toRemove.ISBNGet());
        }

        public void AddBook(Book newBook)
        {
            if (this.HaveBookInCol(newBook))
            {
                throw new ArgumentException("Have this book in the collection.");
            }

            booksToAdd.Add(newBook);
            myCollection.Add(newBook);
            isbnBook[newBook.ISBNGet()] = newBook;
        }

        public void RemoveBook(Book removeBook)
        {
            if (!this.HaveBookInCol(removeBook))
            {
                throw new ArgumentException("Dont have this book in the collection.");
            }

            RemoveFromCollections(removeBook);
            booksToRemove.Add(removeBook);
        }

        public Book[] SortBooksByTag(IComparer<Book> comparer)
        {
            myCollection.Sort(comparer);
            IsSorted = true;
            return myCollection.ToArray();
        }

        public Book[] FindBookByTag(string parameter, string value)
        {
            List<Book> result = new List<Book>();
            switch (parameter.ToUpperInvariant())
            {
                case "ISBN":
                    result.Add(isbnBook[value]);
                    break;
                case "AUTHOR":
                    foreach (Book b in myCollection)
                    {
                        if (value == b.Author)
                            result.Add(b);
                    }
                    break;
                case "NAME":
                    foreach (Book b in myCollection)
                    {
                        if (value == b.Name)
                            result.Add(b);
                    }
                    break;
                case "PUBLISHER":
                    foreach (Book b in myCollection)
                    {
                        if (value == b.Publisher)
                            result.Add(b);
                    }
                    break;
                case "YEAR":
                    foreach (Book b in myCollection)
                    {
                        if (int.Parse(value) == b.Year)
                            result.Add(b);
                    }
                    break;
                case "NUMBEROFPAGES":
                    foreach (Book b in myCollection)
                    {
                        if (int.Parse(value) == b.NumberOfPages)
                            result.Add(b);
                    }
                    break;
                case "COST":
                    foreach (Book b in myCollection)
                    {
                        if (decimal.Parse(value) == b.Cost)
                            result.Add(b);
                    }
                    break;
                default:
                    throw new ArgumentException();
            }
            return result.ToArray();
        }

        public void UpdateStorage()
        {
            if (IsSorted)
            {
                storage.UpdateAllStorage(BookListStorage.FileType.Binary, myCollection.ToArray());
            }
            else
            {
                storage.AddToStorage(BookListStorage.FileType.Binary, booksToAdd.ToArray());
                storage.DeleteFromStorage(BookListStorage.FileType.Binary, booksToRemove.ToArray());
            }
        }
    }
}
