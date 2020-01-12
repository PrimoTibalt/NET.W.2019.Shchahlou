namespace NET.W._2019.Shchahlou._10.Book
{
    using System;
    using NET.W._2019.Shchahlou._10.Book.Interfaces;

    public class BookListStorage
    {
        private IBookStorage CurrentStorage { get; }

        public BookListStorage(IBookStorage storage, string file) : this(storage)
        {
            if (!string.IsNullOrWhiteSpace(file))
            {
                storage.FilePath = file;
            }
        }

        public BookListStorage(IBookStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage", "Try to set null as storage.");
            }

            this.CurrentStorage = storage;
        }

        /// <summary>
        /// Adds input books at the end of file in storage.
        /// </summary>
        /// <param name="books"></param>
        public void AddToStorage(params Book[] books)
        {
            if (books == null)
            {
                Console.WriteLine("STRANGE: TRY TO ADD NULL TO STORAGE.");
            }

            this.CurrentStorage.Write(books);
        }

        /// <summary>
        /// Deletes input books from current storage.
        /// </summary>
        /// <param name="books"></param>
        public void DeleteFromStorage(params Book[] books)
        {
            if (books == null)
            {
                Console.WriteLine("STRANGE: TRY TO DELETE NULL FROM STORAGE.");
            }

            this.CurrentStorage.Delete(books);
        }

        /// <summary>
        /// Deletes books from storage and writes input books.
        /// </summary>
        /// <param name="books"></param>
        public void UpdateAllStorage(Book[] books)
        {
            if (books == null)
            {
                Console.WriteLine("STRANGE: TRY TO ADD NULL OF BOOKS WHILE UPDATION TO STORAGE.");
            }

            this.CurrentStorage.FullUpdate(books);
        }

        /// <summary>
        /// Get information from current storage.
        /// </summary>
        /// <returns>Array of books from current storage.</returns>
        public Book[] ReadFromStorage()
        {
            Book[] books = this.CurrentStorage.ReadFromStorage();
            if (books == null)
            {
                Console.WriteLine("STRANGE: READ NULL FROM STORAGE.");
            }

            return books;
        }
    }
}
