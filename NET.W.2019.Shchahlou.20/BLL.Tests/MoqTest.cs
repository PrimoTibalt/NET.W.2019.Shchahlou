namespace BLL.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using Moq;
    using DAI.Interface.Interfaces;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;

    public class MoqTest
    {
        public static Mock<IRepository<IAccount>> mock;
        
        public static void TestMoqRepository()
        {
            List<IAccount> list = new List<IAccount>
            {
                new SilverAccount("John", 10),
                new BaseAccount("Logan", 20),
                new SilverAccount("Reno", -156),
                new BaseAccount("Anny", 0),

            };

            mock = new Mock<IRepository<IAccount>>();
            mock.Setup(foo => foo.AddToAccountList(It.IsAny<IAccount>()));
            mock.Setup(foo => foo.DeleteAccount(It.IsAny<IAccount>()));
            mock.Setup(foo => foo.GetAccountsList()).Returns(list);

            // I'm afraid, what am I doing?
        }
    }
}
