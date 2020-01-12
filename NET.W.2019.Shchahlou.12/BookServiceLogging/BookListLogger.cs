namespace NET.W._2019.Shchahlou._12.Book
{
    using NLog;
    using NLog.Fluent;

    public interface IBookListLogger
    {
        public void Debug(string message);

        public void Trace(string message);

        public void Info(string message);

        public void Warn(string message);

        public void Error(string message);

        public void Fatal(string message);
    }

    /// <summary>
    /// Use NLog framework for logging
    /// </summary>
    public class NLogBookListLogger : IBookListLogger
    {
        private Logger logger = LogManager.GetLogger("Logger");

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Trace(string message)
        {
            logger.Trace(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }
    }
}