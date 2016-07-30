using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
    }
}