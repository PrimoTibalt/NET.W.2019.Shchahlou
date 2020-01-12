namespace NET.W._2019.Shchahlou._10.Book
{
    using System;
    using System.Collections.Generic;
    using NET.W._2019.Shchahlou._10.Book.Storages;
    using NET.W._2019.Shchahlou._10.Book.Interfaces;

    /// <summary>
    /// Service for Books.
    /// </summary>
    public class BookListService
    {
        private List<Book> collection;

        private bool sorted = false;

        private Dictionary<string, Book> isbnBook = new Dictionary<string, Book>();

        private List<Book> booksToRemove;

        private List<Book> booksToAdd;

        private BookListStorage storage;

        /// <summary>
        /// Implement BookListService.
        /// </summary>
        /// <param name="books"></param>
        /// <param name="filePathForStorage"></param>
        public BookListService(Book[] books, IBookStorage storage, string filePathForStorage = null)
        {
            this.collection = new List<Book>();
            this.booksToAdd = new List<Book>();
            this.booksToRemove = new List<Book>();
            this.storage = new BookListStorage(storage, filePathForStorage);
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

            this.booksToAdd.Add(newBook);
            this.collection.Add(newBook);
            this.isbnBook[newBook.ISBNGet()] = newBook;
        }

        /// <summary>
        /// Removes from local and adds in booksToRemove.
        /// </summary>
        /// <param name="removeBook"></param>
        public void RemoveBook(Book removeBook)
        {
            if (!this.HaveBookInCol(removeBook))
            {
                throw new ArgumentException("Dont have this book in the collection.");
            }

            this.RemoveFromCollections(removeBook);
            this.booksToRemove.Add(removeBook);
        }

        /// <summary>
        /// Sorts collection, set sorted equal to true.
        /// </summary>
        /// <param name="comparer"></param>
        /// <returns>sorted collection</returns>
        public Book[] SortBooksByTag(IComparer<Book> comparer)
        {
            this.collection.Sort(comparer);
            this.sorted = true;
            return collection.ToArray();
        }

        /// <summary>
        /// Variants of parameter:
        /// ISBN, AUTHOR, NAME, PUBLISHER, YEAR, NUMBEROFPAGES, COST.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Book[] FindBookByTag(string parameter, string value)
        {
            List<Book> result = new List<Book>();
            switch (parameter.ToUpperInvariant())
            {
                case "ISBN":
                    result.Add(this.isbnBook[value]);
                    break;
                case "AUTHOR":
                    foreach (Book b in this.collection)
                    {
                        if (b.Author.Contains(value))
                        {
                            result.Add(b);
                        }
                    }

                    break;
                case "NAME":
                    foreach (Book b in this.collection)
                    {
                        if (b.Name.Contains(value))
                        {
                            result.Add(b);
                        }
                    }

                    break;
                case "PUBLISHER":
                    foreach (Book b in this.collection)
                    {
                        if (b.Publisher.Contains(value))
                        {
                            result.Add(b);
                        }
                    }

                    break;
                case "YEAR":
                    foreach (Book b in this.collection)
                    {
                        if (int.Parse(value) == b.Year)
                        {
                            result.Add(b);
                        }
                    }

                    break;
                case "NUMBEROFPAGES":
                    foreach (Book b in this.collection)
                    {
                        if (int.Parse(value) == b.NumberOfPages)
                        {
                            result.Add(b);
                        }
                    }

                    break;
                case "COST":
                    foreach (Book b in this.collection)
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

        /// <summary>
        /// If storage is sorted, than updates all the storage.
        /// if storage isnt sorted, than addes and after that deletes books.
        /// </summary>
        public void UpdateStorage()
        {
            if (this.sorted)
            {
                this.storage.UpdateAllStorage(collection.ToArray());
            }
            else
            {
                this.storage.AddToStorage(booksToAdd.ToArray());
                this.storage.DeleteFromStorage(booksToRemove.ToArray());
                this.booksToAdd.Clear();
                booksToRemove.Clear();
            }
        }

        /// <summary>
        /// Show books from class collection.
        /// </summary>
        public void ShowLocal()
        {
            foreach (var book in this.collection)
            {
                Console.WriteLine(book.ToString());
            }
        }

        /// <summary>
        /// Show books from storage collection.
        /// </summary>
        public void ShowStorage()
        {
            Book[] booksFromStorage = this.storage.ReadFromStorage();
            foreach (var book in booksFromStorage)
            {
                Console.WriteLine(book.ToString());
            }
        }

        /// <summary>
        /// Checks does we have input book in local collection.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        private bool HaveBookInCol(Book book)
        {
            return this.isbnBook.ContainsKey(book.ISBNGet());
        }

        /// <summary>
        /// Used by RemoveBook.
        /// Removes from local collection, from booksToAdd and from isbnBook.
        /// </summary>
        /// <param name="book"></param>
        private void RemoveFromCollections(Book book)
        {
            this.collection.Remove(book);
            this.booksToAdd.Remove(book);
            this.isbnBook.Remove(book.ISBNGet());
        }
    }
}
