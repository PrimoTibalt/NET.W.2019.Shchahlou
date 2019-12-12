using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NET.W._2019.Shchahlou._12
{
    public class BookListStorage
    {
       
        public string binaryFilePath = AppDomain.CurrentDomain.BaseDirectory + @"BookListStorage.bin";
        public string xmlFilePath = AppDomain.CurrentDomain.BaseDirectory + @"BookListStorage.xml";
        public string jsonFilePath = AppDomain.CurrentDomain.BaseDirectory + @"BookListStorage.json";

        public enum FileType
        {
            Binary,
            Xml,
            Json,
        }

        public BookListStorage(string file, FileType type)
        {
            if (!string.IsNullOrEmpty(file))
            {
                switch (type)
                {
                    case FileType.Binary:
                        binaryFilePath = AppDomain.CurrentDomain.BaseDirectory+file;
                        break;
                    case FileType.Xml:
                        throw new NotImplementedException();
                    case FileType.Json:
                        throw new NotImplementedException();
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Writes at the end some file (type.Binary, type.Xml, type.Json)
        /// </summary>
        /// <param name="type">enum BookListStorage.FileType</param>
        /// <param name="books">Books to write</param>
        public void AddToStorage(FileType type, params Book[] books)
        {
            switch (type)
            {
                case FileType.Binary:
                    WriteInBinary(books);
                    break;
                case FileType.Xml:
                    throw new NotImplementedException();
                case FileType.Json:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Deletes array of Books from some file (type.Binary, type.Xml, type.Json)
        /// </summary>
        /// <param name="type">enum BookListStorage.FileType</param>
        /// <param name="books">books to remove</param>
        public void DeleteFromStorage(FileType type, params Book[] books)
        {
            switch (type)
            {
                case FileType.Binary:
                    DeleteFromBinary(books);
                    break;
                case FileType.Xml:
                    throw new NotImplementedException();
                case FileType.Json:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Updates(delete and add books storage in some file (type.Binary, type.Xml, type.Json)
        /// </summary>
        /// <param name="type">enum BookListStorage.FileType</param>
        /// <param name="books">new Books</param>
        public void UpdateAllStorage(FileType type, Book[] books)
        {
            switch (type)
            {
                case FileType.Binary:
                    FullUpdateBinary(books);
                    break;
                case FileType.Xml:
                    throw new NotImplementedException();
                case FileType.Json:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Reads Books from some file (type.Binary, type.Xml, type.Json).
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Books from some file</returns>
        public Book[] ReadFromStorage(FileType type)
        {
            var books = type switch
            {
                FileType.Binary => ReadFromBinary(),
                FileType.Xml => throw new NotImplementedException(),
                FileType.Json => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
            return books;
        }

        /// <summary>
        /// Writes at the end of file new Books(serialized).
        /// </summary>
        /// <param name="newBooks"></param>
        private void WriteInBinary(Book[] newBooks)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream(binaryFilePath, FileMode.OpenOrCreate))
            {
                using (BinaryWriter writter = new BinaryWriter(file))
                {
                    binFormatter.Serialize(file, newBooks);
                }
            }
        }

        /// <summary>
        /// Reads from binaryFilePaths
        /// </summary>
        /// <returns>Books array from binaryFilePath</returns>
        private Book[] ReadFromBinary()
        {
            Book[] books;
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (BinaryReader writter = new BinaryReader(file))
                {
                    books = binFormatter.Deserialize(file) as Book[];
                }
            }
            return books;
        }

        /// <summary>
        /// Deletes old file and creates new with new Books.
        /// </summary>
        /// <param name="newBooks"></param>
        private void FullUpdateBinary(Book[] newBooks)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream(binaryFilePath, FileMode.Create))
            {
                using (BinaryWriter writter = new BinaryWriter(file))
                {
                    binFormatter.Serialize(file, newBooks);
                }
            }
        }

        /// <summary>
        /// Deletes array of Books from binaryFilePath
        /// </summary>
        /// <param name="delBooks"></param>
        private void DeleteFromBinary(Book[] delBooks)
        {
            Book[] oldBooks;
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (BinaryReader writter = new BinaryReader(file))
                {
                    oldBooks = binFormatter.Deserialize(file) as Book[];
                }
            }
            ISet<Book> clearBooks = new HashSet<Book>(oldBooks);
            clearBooks.ExceptWith(delBooks);

            List<Book> clear = new List<Book>();
            foreach (Book book in clearBooks)
            {
                clear.Add(book);
            }

            using (FileStream file = new FileStream(binaryFilePath, FileMode.Create))
            {
                using (BinaryWriter writter = new BinaryWriter(file))
                {
                    binFormatter.Serialize(file, clear.ToArray());
                }
            }
        }
    }
}
