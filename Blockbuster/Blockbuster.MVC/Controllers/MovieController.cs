
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;
using Blockbuster.Service.IService;
using Blockbuster.Service.Service;

namespace Blockbuster.MVC.Controllers
{
    public class MovieController : Controller
    {
        public IBaseService<Movie> MovieService { get; set; } 
        // GET: Movie

        public MovieController()
        {
            MovieService = new MovieService(new MovieRepository(new Context()));
        }
        public ActionResult Index()
        {
            var movies = MovieService.Query().Include(movie => movie.Genre).ToList();
            return View(movies);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            MovieService.Insert(movie);
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(string id)
        {
            var movie = MovieService.Find(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            MovieService.Update(movie);
            return RedirectToAction("Index", "Movie");
        }
    }
}