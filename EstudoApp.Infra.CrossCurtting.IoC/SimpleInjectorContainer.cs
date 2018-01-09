using System.Reflection;
using System.Web.Mvc;
using EstudoApp.Data.Repositories;
using EstudoApp.Domain.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace EstudoApp.Infra.CrossCurtting.IoC
{
    public static class SimpleInjectorContainer
    {
        public static Container Container;

        public static Container RegisterServices()
        {
            Container = new Container();

            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            Container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            Container.Register<INinjaRepository, NinjaRepository>(Lifestyle.Scoped);
            Container.Register<INinjaClanRepository, NinjaClanRepository>(Lifestyle.Scoped);

            Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            Container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));

            return Container;
        }
    }
}
