namespace NET.W._2019.Shchahlou._8.Book.Interfaces
{
    public interface IBookStorage
    {
        public string FilePath { get; set; }

        public FileType Type { get; }

        public void Write(params Book[] books);

        public void Delete(params Book[] books);

        /// <summary>
        /// Deletes all books from storage and saves new books(input).
        /// </summary>
        /// <param name="books"></param>
        public void FullUpdate(params Book[] books);

        public Book[] ReadFromStorage();
    }
}
