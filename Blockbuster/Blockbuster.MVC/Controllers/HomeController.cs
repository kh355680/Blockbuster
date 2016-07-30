
using System.Web.Mvc;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Service.IService;

namespace Blockbuster.MVC.Controllers
{
    public class HomeController : Controller
    {
               
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }
    }
}