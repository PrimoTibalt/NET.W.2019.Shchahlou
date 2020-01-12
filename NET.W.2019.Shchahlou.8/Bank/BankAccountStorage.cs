namespace NET.W._2019.Shchahlou._8.Bank
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using NET.W._2019.Shchahlou._8.Bank.Interfaces;

    public class BinaryStorage : IAccountStorage
    {
        private string filePath = AppDomain.CurrentDomain.BaseDirectory + @"Account.bin";

        public string FilePath
        {
            get
            {
                return filePath;
            }

            set
            {
                if (File.Exists(value))
                {
                    filePath = value;
                }
            }
        }

        /// <summary>
        /// Save account with serialization in file on filePath.
        /// </summary>
        /// <param name="ba"></param>
        public void Store(IBankAccount ba)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using FileStream file = new FileStream(@filePath, FileMode.OpenOrCreate);
            using BinaryWriter writter = new BinaryWriter(file);
            binFormatter.Serialize(file, ba);
        }
    }
}
