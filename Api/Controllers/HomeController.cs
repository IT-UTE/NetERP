using System.Web.Mvc;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Partial(string partial)
        {
            return File(partial, "text/html");
        }
    }
}
