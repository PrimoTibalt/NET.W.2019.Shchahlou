using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NET.W._2019.Shchahlou._8
{
    public class BookListStorage
    {
       
        public string binaryFilePath = @"BookListStorage.bin";
        public string xmlFilePath = @"BookListStorage.xml";
        public string jsonFilePath = @"BookListStorage.json";

        public enum FileType
        {
            Binary,
            Xml,
            Json,
        }

        public BookListStorage(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
                binaryFilePath = filePath;
        }

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
                
                SortedSet<Book> clearBooks = new SortedSet<Book>(oldBooks);
                clearBooks.ExceptWith(delBooks);

                List<Book> clear = new List<Book>();
                foreach(Book book in clearBooks)
                {
                    clear.Add(book);
                }

                using (BinaryWriter writter = new BinaryWriter(file))
                {
                    binFormatter.Serialize(file, clear.ToArray());
                }
            }
        }

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

        public Book[] ReadFromStorage(FileType type)
        {
            Book[] books;
            switch (type)
            {
                case FileType.Binary:
                    books = ReadFromBinary();
                    break;
                case FileType.Xml:
                    throw new NotImplementedException();
                case FileType.Json:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
            return books;
        }
    }
}
