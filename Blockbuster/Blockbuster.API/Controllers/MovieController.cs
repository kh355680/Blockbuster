
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;
using Blockbuster.Service.Service;

namespace Blockbuster.API.Controllers
{
    public class MovieController : BaseController<Movie>
    {
        public MovieController():base(new MovieService(new MovieRepository(new Context())))
        {
            
        }

        [Route("api/movie/casting/{movieId}")]
        [HttpGet]
        public IHttpActionResult MovieCasting([FromUri]string movieId)
        {
            var db = new Context();
            var casting = db.MovieCasts.Where(m => m.MovieId == movieId).ToList();

            List<Artist> actors = new List<Artist>();
            
            foreach (var movieCast in casting)
            {
                var actor = db.Artists.Find(movieCast.ArtistId);
                actors.Add(actor);
            }

            return Ok(actors);
                       
        }
    }
}