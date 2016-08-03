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

            var movieCasts = MovieCastService.Query().Where(x => x.MovieId == id).Include( x => x.Artist).ToList();
            ViewBag.Movie = movie;
            return View(movieCasts);
        }

        [HttpGet]
        public ActionResult Create(string id)
        {
            var movie = new MovieService(new MovieRepository(new Context())).Find(id);
            ViewBag.Movie = movie;

            var movieCast = new MovieCast()
            {
                MovieId = movie.Id
            };

            ViewBag.ArtistList = new ArtistService(new ArtistRepository(new Context())).Query();
            return View(movieCast);
        }

        [HttpPost]
        public ActionResult Create(MovieCast movieCast)
        {
            //var movie = new MovieService(new MovieRepository(new Context())).Find(id);
            //ViewBag.Movie = movie;
            MovieCastService.Insert(movieCast);
            return RedirectToAction("Index","MovieCast",new {id = movieCast.MovieId});
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var movieCast = MovieCastService.Find(id);

            var movie = new MovieService(new MovieRepository(new Context())).Find(movieCast.MovieId);
            ViewBag.Movie = movie;

            ViewBag.ArtistList = new ArtistService(new ArtistRepository(new Context())).Query();
            return View(movieCast);
        }

        public ActionResult Edit(MovieCast movieCast)
        {
            MovieCastService.Update(movieCast);
            return RedirectToAction("Index", "MovieCast", new { id = movieCast.MovieId });
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var movieCast = MovieCastService.Find(id);
            return View(movieCast);
        }

        [HttpPost]
        public ActionResult Delete(MovieCast movieCast)
        {
            MovieCastService.Delete(movieCast.Id);
            return RedirectToAction("Index", "MovieCast", new { id = movieCast.MovieId });
        }
    }
}