namespace NET.W._2019.Shchahlou._17.XML
{
    using System;
    using System.Text;
    using System.IO;
    using NLog;
    using NET.W._2019.Shchahlou._17.XML.Interfaces;

    /// <summary>
    /// Class to Read urls from file.
    /// If some of urls doesn't fit to project, then they ignores and logges them number in file.
    /// </summary>
    public class FileReader : IFileReader
    {
        private readonly string filePath;

        private readonly ILogger logger = LogManager.GetLogger("Logger");

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
            string[] urls = reader.ReadToEnd().Split("\n");
            return ValidationStr(urls);
        }

        /// <summary>
        /// Validation urls by : they have protocol, host, uri and parameters(only if they have uri).
        /// </summary>
        /// <param name="urls"></param>
        /// <returns>Valid urls</returns>
        private string[] ValidationStr(string[] urls)
        {
            if (urls == null)
            {
                throw new ArgumentNullException("urls", "Don't have any string in file.");
            }

            StringBuilder bldr = new StringBuilder();
            for (int i = 0; i < urls.Length; i++)
            {
                string curUrl = urls[i];
                if (!curUrl.Contains("http") || !curUrl.Contains("://"))
                {
                    logger.Warn($"{i} url dont have protocol. Or it doesnt well formed.");
                    continue;
                }

                curUrl.Replace("://", string.Empty);
                if (curUrl.Contains("?") && !curUrl.Contains("/"))
                {
                    logger.Warn($"{i} url have parameters, but dont have any uri.");
                }

                bldr.AppendLine(curUrl);
            }

            logger.Trace($"Validation completed, number of URLs {bldr.ToString().Split("\n").Length - 1}");
            return bldr.ToString().Split("\n");
        }
    }
}
