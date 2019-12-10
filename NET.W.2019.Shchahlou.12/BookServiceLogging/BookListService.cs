using System;
using System.Collections.Generic;

namespace NET.W._2019.Shchahlou._12
{
    /// <summary>
    /// Class to use your Book's right
    /// Contains methods to save on computer 
    /// your Books, sort them, add new and delete old
    /// </summary>
    public class BookListService
    {
        private static IBookListLogger logger;

        private List<Book> collection;

        private bool sorted = false;

        private Dictionary<string, Book> isbnBook = new Dictionary<string, Book>();

        private List<Book> booksToRemove;

        private List<Book> booksToAdd;

        private BookListStorage storage;

        public BookListService(Book[] books, string filePathForStorage = null)
        {
            logger.Trace("User initialized BookListService object");
            if (filePathForStorage == null)
            {
                logger.Warn("User didnt set filePathForStorage");
            }

            collection = new List<Book>();
            booksToAdd = new List<Book>();
            booksToRemove = new List<Book>();

            logger.Debug("Initialize storage.");
            storage = new BookListStorage(filePathForStorage, BookListStorage.FileType.Binary);
            foreach (Book b in books)
            {
                this.AddBook(b);
            }
        }

        public void AddBook(Book newBook)
        {
            logger.Trace($"Start adding Book {newBook.ToString("I-N-W-A-C-P")}.");
            if (newBook == null)
            {
                logger.Error("User try to add Book which is null");
                throw new ArgumentNullException("newBook is null!");
            }

            if (this.HaveBookInCol(newBook))
            {
                logger.Error($"User has a Book {newBook.ISBNGet()} in isbnBook.");
                throw new ArgumentException("Have this book in the collection.");
            }

            logger.Trace($"Add Book {newBook.ISBNGet()} in booksToAdd.");
            booksToAdd.Add(newBook);
            logger.Trace($"Add Book {newBook.ISBNGet()} in collection.");
            collection.Add(newBook);
            logger.Trace($"Add Book {newBook.ISBNGet()} in isbnBook.");
            isbnBook[newBook.ISBNGet()] = newBook;
        }

        public void RemoveBook(Book removeBook)
        {
            logger.Trace($"Remove Book {removeBook.ISBNGet()} in collection.");
            if (!this.HaveBookInCol(removeBook))
            {
                logger.Error($"User doesnt have a Book {removeBook.ISBNGet()} in isbnBook.");
                throw new ArgumentException("Dont have this book in the collection.");
            }

            logger.Trace($"Remove Book {removeBook.ISBNGet()} from collections and dictionaries.");
            RemoveFromCollections(removeBook);
            logger.Trace($"Add Book {removeBook.ISBNGet()} in booksToRemove.");
            booksToRemove.Add(removeBook);
        }

        public Book[] SortBooksByTag(IComparer<Book> comparer)
        {
            logger.Trace("User sorts collection by some somparer.");
            if (comparer == null)
            {
                logger.Warn("User send null as comparer.");
            }

            if (collection.Count == 0)
            {
                logger.Warn("User tries to sort empty collection.");
            }

            collection.Sort(comparer);
            sorted = true;
            return collection.ToArray();
        }

        public Book[] FindBookByTag(string parameter, string value)
        {
            logger.Trace($"Try to find Book with {parameter}: {value}.");
            if (value == null)
            {
                logger.Warn($"User use null as value to Find");
            }

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
                    logger.Warn($"User used strange parameter: {parameter}.");
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

            booksToAdd.Clear();
            booksToRemove.Clear();
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
            if (book == null)
            {
                logger.Error("User try to check Book which is null.");
                throw new ArgumentNullException();
            }

            return isbnBook.ContainsKey(book.ISBNGet());
        }

        private void RemoveFromCollections(Book book)
        {
            if (book == null)
            {
                logger.Error("User try to delete Book which is null.");
                throw new ArgumentNullException();
            }

            try
            {
                logger.Trace($"Remove Book {book.ISBNGet()} from collection.");
                collection.Remove(book);
                logger.Trace($"Remove Book {book.ISBNGet()} from booksToAdd.");
                booksToAdd.Remove(book);
                logger.Trace($"Remove Book {book.ISBNGet()} from isbnBook.");
                isbnBook.Remove(book.ISBNGet());
            }
            catch (Exception e)
            {
                logger.Error($"Error while removing Book {book.ISBNGet()}.\nError message: \n{e.ToString()}.");
            }
        }
    }
}
