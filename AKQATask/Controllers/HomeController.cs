#region Namespaces
using AKQATask.Models;
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
            //Default value set through passing fixed model
            
            var model = new TaskModel()
            {
                Name = "John Smith",
                Value = "123.45"
            };
            return View(model);
        }
        #endregion

    }
}
#endregion