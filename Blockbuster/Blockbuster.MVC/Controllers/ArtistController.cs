

using System.Web.Mvc;
using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;
using Blockbuster.Service.IService;
using Blockbuster.Service.Service;

namespace Blockbuster.MVC.Controllers
{
    public class ArtistController : Controller
    {
        public IBaseService<Artist> ArtistService { get; set; }

        public ArtistController()
        {
            ArtistService = new ArtistService(new ArtistRepository(new Context()));
        }

        // GET: Artist
        public ActionResult Index()
        {
            var artists = ArtistService.Query();
            return View(artists);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Artist artist)
        {
            ArtistService.Insert(artist);
            return RedirectToAction("Index", "Artist");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var artist = ArtistService.Find(id);
            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            ArtistService.Update(artist);
            return RedirectToAction("Index", "Artist");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var artist = ArtistService.Find(id);
            return View(artist);
        }

        [HttpPost]
        public ActionResult Delete(Artist artist)
        {
            var artistToDelete = ArtistService.Find(artist.Id);
            ArtistService.Delete(artistToDelete.Id);
            return RedirectToAction("Index","Artist");
        }

    }
}