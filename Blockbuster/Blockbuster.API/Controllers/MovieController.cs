
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;

namespace Blockbuster.API.Controllers
{
    public class MovieController : ApiController
    {
        public BaseRepository<Movie> Repository { get; set; }

        public MovieController()
        {
            Repository = new BaseRepository<Movie>();
        }

        [HttpGet]        
        public IHttpActionResult Get()
        {
            return Ok(Repository.GetAll().ToList());
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(Repository.GetById(id));
        }


        [HttpPost]
        public async Task<IHttpActionResult> Post(Movie movie)
        {
            movie.Id = Guid.NewGuid().ToString();
            return Ok(await Repository.Insert(movie));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(Movie movie)
        {
            return Ok(await Repository.Update(movie));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id)
        {
            return Ok(await Repository.Remove(id));
        } 
         
    }
}
