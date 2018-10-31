namespace WebAPI_EF_CodeFirstFromDb
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;
    using WebAPI_EF_CodeFirstFromDb.Controllers;
    using WebAPI_EF_CodeFirstFromDb.Models;
    using WebAPI_EF_CodeFirstFromDb.Service;
    using WebAPI_EF_CodeFirstFromDb.UoW;

    // References:
    // https://www.c-sharpcorner.com/article/using-autofac-with-web-api/
    // https://autofaccn.readthedocs.io/en/latest/index.html
    public class AutofacConfig
    {
        private static IContainer container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(config, new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(HttpConfiguration config, ContainerBuilder builder)
        {
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);
            builder.Register(c => new UoW.UoWActionFilter(c.Resolve<IUnitOfWork>()))
                .AsWebApiActionFilterFor<VehiclesController>()
                .InstancePerRequest();

            builder.RegisterType<EFContext>()
                   .As<DbContext>()
                   .InstancePerRequest();

            builder.RegisterType<VehicleService>()
                   .As<IVehicleService>()
                   .InstancePerRequest();

            builder.RegisterType<ManufacturerService>()
                   .As<IManufacturerService>()
                   .InstancePerRequest();

            builder.RegisterType<Repository.Repository>()
                   .As<Repository.IRepository>()
                   .InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                   .As<IUnitOfWork>()
                   .InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            container = builder.Build();

            return container;
        }
    }
}