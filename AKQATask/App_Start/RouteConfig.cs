#region Namespaces
using System.Web.Mvc;
using System.Web.Routing;
#endregion

#region Main Code
namespace AKQATask
{
    public class RouteConfig
    {
        #region Public Methods
        /// <summary>
        /// Register Controller Route detail
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
        #endregion
    }
}
#endregion