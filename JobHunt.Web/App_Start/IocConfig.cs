using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac.Integration.WebApi;
using JobHunt.Data;
using JobHunt.Web;


namespace JobHunt.Web
{
    public class IocConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<JobHuntContext>().As<IEntityContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.Register<Func<IPrincipal>>(c => () => HttpContext.Current.User);

         

            var assembly = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterFilterProvider();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}