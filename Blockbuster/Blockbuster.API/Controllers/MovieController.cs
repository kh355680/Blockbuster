
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;
using Blockbuster.Service.IService;
using Blockbuster.Service.Service;

namespace Blockbuster.API.Controllers
{
    public class MovieController : ApiController
    {
        public IBaseService<Movie> Service { get; set; }

        public MovieController()
        {
            var repository = new BaseRepository<Movie>();
            Service = new BaseService<Movie>(repository);
        }

        [HttpGet]        
        public IHttpActionResult Get()
        {
            return Ok(Service.Query().ToList());
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(Service.Find(id));
        }


        [HttpPost]
        public async Task<IHttpActionResult> Post(Movie movie)
        {
            movie.Id = Guid.NewGuid().ToString();
            return Ok(await Service.Insert(movie));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(Movie movie)
        {
            return Ok(await Service.Update(movie));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id)
        {
            return Ok(await Service.Delete(id));
        } 
         
    }
}
