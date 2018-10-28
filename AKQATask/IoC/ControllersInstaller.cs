using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using System.Web.Mvc;
using AKQATask.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AKQATask.IoC
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                .BasedOn<Controller>()
                .If(Component.IsInSameNamespaceAs<HomeController>())
                .LifestyleTransient());
            container.Register(AllTypes.FromThisAssembly()
                .BasedOn<ApiController>()
                .If(Component.IsInSameNamespaceAs<ResultAPIController>())
                .LifestyleTransient());
        }

        //private ConfigureDelegate ConfigureControllers()
        //{
        //    return c => c.LifeStyle.Transient;
        //}

        private BasedOnDescriptor FindControllers()
        {
            return AllTypes.FromThisAssembly()
                .BasedOn<IController>()
                .If(Component.IsInSameNamespaceAs<HomeController>())
                .If(t => t.Name.EndsWith("Controller")).LifestyleTransient();
        }
    }

}