﻿using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace AKQATask
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           
            // IOC not implementated currently as there is not such big implementation
            // BootstrapContainer();

        }

        //private static void BootstrapContainer()
        //{
        //    container = new WindsorContainer()
        //         .Install(FromAssembly.This());

        //    var controllerFactory = new WindsorControllerFactory(container.Kernel);
        //    ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        //}

        //static IWindsorContainer container;
        //public IWindsorContainer Container
        //{
        //    get { return container; }
        //}
    }
}