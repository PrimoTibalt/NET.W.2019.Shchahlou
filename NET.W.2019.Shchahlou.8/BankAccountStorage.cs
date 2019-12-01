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
        public string FilePath = "Account.bin";

        public void Store(BankAccount ba)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream(@FilePath, FileMode.OpenOrCreate))
            {
                using (BinaryWriter writter = new BinaryWriter(file))
                {
                    binFormatter.Serialize(file, ba);
                }
            }
        }
    }
}
