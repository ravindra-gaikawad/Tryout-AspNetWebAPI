using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WebAPI_EF_CodeFirstFromDb.Models;
using WebAPI_EF_CodeFirstFromDb.Service;
using WebAPI_EF_CodeFirstFromDb.UoW;

namespace WebAPI_EF_CodeFirstFromDb
{
    //References:
    // https://www.c-sharpcorner.com/article/using-autofac-with-web-api/
    // https://autofaccn.readthedocs.io/en/latest/index.html
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

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

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}