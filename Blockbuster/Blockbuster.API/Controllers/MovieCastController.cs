
using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;
using Blockbuster.Service.Service;

namespace Blockbuster.API.Controllers
{
    public class MovieCastController : BaseController<MovieCast>
    {
        public MovieCastController():base(new MovieCastService(new MovieCastRepository(new Context())))
        {
            
        }
    }
}