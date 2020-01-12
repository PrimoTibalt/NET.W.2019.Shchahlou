namespace NET.W._2019.Shchahlou._10.Book.Storages
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Runtime.Serialization.Formatters.Binary;
    using NET.W._2019.Shchahlou._10.Book.Interfaces;

    /// <summary>
    /// Storage in binary format.
    /// </summary>
    public class BinaryStorage : IBookStorage
    {
        public string FilePath { get; set; }

        public BinaryStorage()
        {
            this.FilePath = AppDomain.CurrentDomain.BaseDirectory + @"BookListStorage.bin";
        }

        public FileType Type => FileType.Binary;

        /// <summary>
        /// At first - read books from storage.
        /// Than deletes input books from books from storage.
        /// than saves books like and array of them.
        /// </summary>
        /// <param name="books"></param>
        public void Delete(params Book[] books)
        {
            Book[] oldBooks;
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream(this.FilePath, FileMode.Open))
            {
                oldBooks = binFormatter.Deserialize(file) as Book[];
            }

            ISet<Book> clearBooks = new HashSet<Book>(oldBooks);
            clearBooks.ExceptWith(books);

            List<Book> clear = new List<Book>();
            foreach (Book book in clearBooks)
            {
                clear.Add(book);
            }

            using (FileStream file = new FileStream(this.FilePath, FileMode.Create))
            {
                binFormatter.Serialize(file, clear.ToArray());
            }
        }

        /// <summary>
        /// Create new file with same name and file path and writes here input books.
        /// </summary>
        /// <param name="books"></param>
        public void FullUpdate(params Book[] books)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using FileStream file = new FileStream(this.FilePath, FileMode.Create);
            binFormatter.Serialize(file, books);
        }

        /// <summary>
        /// Reads all the books from storage.
        /// </summary>
        /// <returns></returns>
        public Book[] ReadFromStorage()
        {
            Book[] books;
            BinaryFormatter binFormatter = new BinaryFormatter();
            using FileStream file = new FileStream(this.FilePath, FileMode.Open);
            books = binFormatter.Deserialize(file) as Book[];
            return books;
        }

        /// <summary>
        /// Reads old books, addes new to them and writes summ.
        /// </summary>
        /// <param name="books"></param>
        public void Write(params Book[] books)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            Book[] booksFromStorage;
            using (FileStream file = new FileStream(this.FilePath, FileMode.OpenOrCreate))
            {
                try
                {
                    booksFromStorage = binFormatter.Deserialize(file) as Book[];
                }
                catch (System.Runtime.Serialization.SerializationException)
                {
                    booksFromStorage = new Book[0];
                }
            }
            
            List<Book> listOfSumm = new List<Book>(booksFromStorage);
            listOfSumm.AddRange(new List<Book>(books));
            using (FileStream fileToWrite = new FileStream(this.FilePath, FileMode.Create))
            {
                binFormatter.Serialize(fileToWrite, listOfSumm.ToArray());
            }
        }
    }
}
