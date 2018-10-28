#region Namespaces
using System.Web.Mvc;
#endregion

#region Main Code
namespace AKQATask.Controllers
{
    public class HomeController : Controller
    {
        #region Public methods
        /// <summary>
        /// Default Action method to load the form with required controls
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        #endregion

    }
}
#endregion