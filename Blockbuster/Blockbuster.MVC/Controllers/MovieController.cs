
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
            ViewBag.GenreList = new GenreService(new GenreRepository(new Context())).Query().ToList();
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
            ViewBag.GenreList = new GenreService(new GenreRepository(new Context())).Query().ToList();
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            MovieService.Update(movie);
            return RedirectToAction("Index", "Movie");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var movie = MovieService.Find(id);
            return View(movie);
        }

        public ActionResult Delete(Movie movie)
        {
            MovieService.Delete(movie.Id);
            return RedirectToAction("Index", "Movie");
        }
    }
}