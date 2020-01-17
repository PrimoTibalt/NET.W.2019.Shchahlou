namespace DependencyResolver
{
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
    using BLL.ServiceImplementation;
    using DAI.Fake;
    using DAI.Interface.Interfaces;
    using DAI.Repositories;
    using Ninject;

    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();

            // kernel.Bind<IRepository>().To<FakeRepository>();
            kernel.Bind<IRepository<Account>>().To<AccountBinaryRepository<Account>>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();

            // kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
