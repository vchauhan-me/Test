#region Namespaces
using System.Web.Http;
#endregion

#region Main Code
namespace AKQATask
{
    public static class WebApiConfig
    {
        #region Public Methods
        /// <summary>
        /// Register WebAPI routes
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = 123.44 }
            );
        }
        #endregion
    }
}
#endregion