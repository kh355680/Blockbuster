
using System.Threading.Tasks;
using System.Web.Http;
using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;
using Blockbuster.Service.IService;
using Blockbuster.Service.Service;

namespace Blockbuster.API.Controllers
{
    public class BaseController<TEntity> : ApiController where TEntity : Entity
    { 
        public IBaseService<TEntity> Service { get; set; }
         
        public BaseController()
        {
            var context = new Context();
            var repository = new BaseRepository<TEntity>(context);
            Service = new BaseService<TEntity>(repository);
        }

        [HttpGet]
        public virtual IHttpActionResult Get()
        {
            return Ok(Service.Query());
        }

        [HttpGet]
        public virtual IHttpActionResult Get(string id)
        {
            return Ok(Service.Find(id));
        }


        [HttpPost]
        public virtual async Task<IHttpActionResult> Post(TEntity entity)
        {
            return Ok(await Service.Insert(entity));
        }

        [HttpPut]
        public virtual async Task<IHttpActionResult> Put(TEntity entity)
        {
            return Ok(await Service.Update(entity));
        }

        [HttpDelete]
        public virtual async Task<IHttpActionResult> Delete(string id)
        {
            return Ok(await Service.Delete(id));
        } 
    }
}
