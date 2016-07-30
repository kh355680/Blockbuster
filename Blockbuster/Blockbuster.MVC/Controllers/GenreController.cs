
using System.Linq;
using System.Web.Mvc;
using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;
using Blockbuster.Service.IService;
using Blockbuster.Service.Service;

namespace Blockbuster.MVC.Controllers
{
    public class GenreController : Controller
    {
        public IBaseService<Genre> GenreService { get; set; }

        public GenreController()
        {
            GenreService = new GenreService(new GenreRepository(new Context()));
        }
        // GET: Genre
        public ActionResult Index()
        {
            var genres = GenreService.Query();

            return View(genres.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            GenreService.Insert(genre);
            return RedirectToAction("Index", "Genre");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var genre = GenreService.Find(id);
            return View(genre);
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            GenreService.Update(genre);
            return RedirectToAction("Index", "Genre");
        }

        public ActionResult Delete(string id)
        {
            GenreService.Delete(id);
            return RedirectToAction("Index", "Genre");
        }
    }
}