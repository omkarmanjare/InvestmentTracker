using Autofac;
using AutoMapper;
using PM.BusinessLayer;
using PM.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac.Integration.WebApi;
using System.Reflection;
using PM.DataContracts;

namespace PortfolioManager
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();//What ContainerBuilder class does/returns

            //Register Web APi Controllers
            // builder.RegisterApiControllers(Assembly.GetAssembly(typeof (PMDefaultController))); //try this one 

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //try this one
            builder.RegisterType<UserOperations>().As<IUserOperations>().InstancePerRequest();
            builder.RegisterType<FDOperations>().As<IFDOperations>().InstancePerRequest();
            // builder.RegisterType<PMOperations>().As<IPMOperations>().InstancePerRequest();

            // builder.RegisterAdapter
            var container = builder.Build();//what it does
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            //Automapper configurations
            Mapper.Initialize(mapperConfiguration =>
            {
                // mapperConfiguration.CreateMap<PMCreateRequest, PMDomainClass>();
                mapperConfiguration.CreateMap<PMCreateRequest, FixedDeposite>();
            }
                                );

        }
    }
}
