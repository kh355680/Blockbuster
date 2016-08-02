using System.Web.Mvc;
using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;
using Blockbuster.Service.IService;
using Blockbuster.Service.Service;

namespace Blockbuster.MVC.Controllers
{
    public class MovieCastController : Controller
    {
        public IBaseService<MovieCast> MovieCastService { get; set; }

        public MovieCastController()
        {
            MovieCastService = new MovieCastService(new MovieCastRepository(new Context()));
        }

        // GET: MovieCast
        public ActionResult Index(string id)
        {
            var movie = new MovieService(new MovieRepository(new Context())).Find(id);
            ViewBag.Movie = movie;
            return View();
        }

        [HttpGet]
        public ActionResult Create(string movieId)
        {
            var movie = new MovieService(new MovieRepository(new Context())).Find(movieId);
            ViewBag.Movie = movie;
            return View();
        }
    }
}