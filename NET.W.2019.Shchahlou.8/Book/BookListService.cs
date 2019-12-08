using System;
using System.Collections.Generic;

namespace NET.W._2019.Shchahlou._8
{
    /// <summary>
    /// 
    /// </summary>
    public class BookListService
    {
        private List<Book> collection;

        private bool sorted = false;

        private Dictionary<string, Book> isbnBook = new Dictionary<string, Book>();

        private List<Book> booksToRemove;

        private List<Book> booksToAdd;

        private BookListStorage storage;

        public BookListService(Book[] books, string filePathForStorage = null)
        {
            collection = new List<Book>();
            booksToAdd = new List<Book>();
            booksToRemove = new List<Book>();
            storage = new BookListStorage(filePathForStorage, BookListStorage.FileType.Binary);
            foreach (Book b in books)
            {
                this.AddBook(b);
            }
        }

        public void AddBook(Book newBook)
        {
            if (this.HaveBookInCol(newBook))
            {
                throw new ArgumentException("Have this book in the collection.");
            }

            booksToAdd.Add(newBook);
            collection.Add(newBook);
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
            collection.Sort(comparer);
            sorted = true;
            return collection.ToArray();
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
                    foreach (Book b in collection)
                    {
                        if (b.Author.Contains(value))
                        {
                            result.Add(b);
                        }
                    }

                    break;
                case "NAME":
                    foreach (Book b in collection)
                    {
                        if (b.Name.Contains(value))
                        {
                            result.Add(b);
                        }
                    }

                    break;
                case "PUBLISHER":
                    foreach (Book b in collection)
                    {
                        if (b.Publisher.Contains(value))
                        {
                            result.Add(b);
                        }
                    }

                    break;
                case "YEAR":
                    foreach (Book b in collection)
                    {
                        if (int.Parse(value) == b.Year)
                        {
                            result.Add(b);
                        }
                    }

                    break;
                case "NUMBEROFPAGES":
                    foreach (Book b in collection)
                    {
                        if (int.Parse(value) == b.NumberOfPages)
                        {
                            result.Add(b);
                        }
                    }

                    break;
                case "COST":
                    foreach (Book b in collection)
                    {
                        if (decimal.Parse(value) == b.Cost)
                        {
                            result.Add(b);
                        }
                    }

                    break;
                default:
                    throw new ArgumentException();
            }

            return result.ToArray();
        }

        public void UpdateStorage()
        {
            if (sorted)
            {
                storage.UpdateAllStorage(BookListStorage.FileType.Binary, collection.ToArray());
            }
            else
            {
                storage.AddToStorage(BookListStorage.FileType.Binary, booksToAdd.ToArray());
                storage.DeleteFromStorage(BookListStorage.FileType.Binary, booksToRemove.ToArray());
            }
        }

        public void ShowLocal()
        {
            throw new NotImplementedException();
        }

        public void ShowStorage()
        {
            throw new NotImplementedException();
        }

        private bool HaveBookInCol(Book book)
        {
            return isbnBook.ContainsKey(book.ISBNGet());
        }

        private void RemoveFromCollections(Book book)
        {
            collection.Remove(book);
            booksToAdd.Remove(book);
            isbnBook.Remove(book.ISBNGet());
        }
    }
}
