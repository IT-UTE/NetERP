using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using System;
using Resolver;

namespace Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = GetConfigedContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static UnityContainer GetConfigedContainer()
        {
            var container = new UnityContainer();
            ComponentLoader.LoadContainer(container, "./bin", "Model.dll");
            ComponentLoader.LoadContainer(container, "./bin", "Services.dll");
            ComponentLoader.LoadContainer(container, "./bin", "Api.dll");
            return container;
        }
    }
}