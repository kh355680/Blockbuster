
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Service.IService;
using Blockbuster.Service.Service;

namespace Blockbuster.API.Controllers
{
    public class GenreController : ApiController
    {

        public IGenreService Service { get; set; }

        private bool _isDataSaved;

        public GenreController()
        {
            Service = new GenreService();
            _isDataSaved = false;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var genres = Service.GetAll();

            if (await genres.CountAsync() > 0)
                return Ok(genres);

            return BadRequest();
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri] string id)
        {
            var genre = Service.GetById(id);

            if (genre != null)
                return Ok(genre);

            return BadRequest("Sorry No Data Found");
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Genre genre)
        {
            genre.Id = Guid.NewGuid().ToString();

            if (ModelState.IsValid)
            {
                var result = await Service.Insert(genre);

                if (result)
                    return Ok("New Genre Created");
            }

            return BadRequest("Invalid Data");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(Genre genre)
        {
            if (ModelState.IsValid)
            {
               var isDataSaved = await Service.Update(genre);

                if (isDataSaved)
                    return Ok("Genre Info Updated");
            }

            return BadRequest("Genre Update Failed");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id)
        {
            _isDataSaved = await Service.Remove(id);

            if (_isDataSaved)
                return Ok("Genre Removed Successfully");

            return BadRequest("Failed");
        } 
    }
}
