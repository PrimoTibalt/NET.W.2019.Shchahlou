using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NET.W._2019.Shchahlou._8
{
    public interface IAccountStorage
    {
        public void Store(BankAccount ba);
    }

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

        public void Store(BankAccount ba)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream(@filePath, FileMode.OpenOrCreate))
            {
                using (BinaryWriter writter = new BinaryWriter(file))
                {
                    binFormatter.Serialize(file, ba);
                }
            }
        }
    }
}
