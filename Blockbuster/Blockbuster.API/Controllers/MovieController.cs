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
    }
}