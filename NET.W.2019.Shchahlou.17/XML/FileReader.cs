namespace NET.W._2019.Shchahlou._17.XML
{
    using System;
    using System.IO;
    using NET.W._2019.Shchahlou._17.XML.Interfaces;

    public class FileReader : IFileReader
    {
        private readonly string filePath;

        /// <summary>
        /// Initialize class with readonly field filePath.
        /// </summary>
        /// <param name="path"></param>
        public FileReader(string path)
        {
            this.filePath = path;
        }

        /// <summary>
        /// Reads file from filePath.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string[] ReadAll()
        {
            using StreamReader reader = new StreamReader(this.filePath);
            return reader.ReadToEnd().Split("\n");
        }
    }
}
