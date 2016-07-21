using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;
using Blockbuster.Service.Service;

namespace Blockbuster.API.Controllers
{
    public class GenreController : BaseController<Genre>
    {
        public GenreController() : base(new GenreService(new GenreRepository(new Context())))
        {
            
        }
    }
}