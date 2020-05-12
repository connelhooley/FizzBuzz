using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FizzBuzz.Domain.Abstract;
using FizzBuzz.Domain.Concrete;

namespace FizzBuzz.WebUi
{
    public static class IocConfig
    {
        public static IContainer Container
        {
            get
            {
                var builder = new ContainerBuilder();

                builder.RegisterControllers(typeof(MvcApplication).Assembly);

                // Register bindings here
                builder.RegisterType<FizzBuzzGenerator>().As<IFizzBuzzGenerator>();
                builder.RegisterType<NowGetter>().As<INowGetter>();
                builder.RegisterType<SettingsStore>().As<ISettingsStore>();
                builder.RegisterType<Pager>().As<IPager>();
                builder.RegisterType<StubUserInputLogger>().As<IUserInputLogger>();

                return builder.Build();
            }
        }

        public static void RegisterBindings() => 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
    }
}