using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;
using Blockbuster.Service.Service;


namespace Blockbuster.API.Controllers
{
    public class ArtistController : BaseController<Artist>
    {
        public ArtistService ArtistService { get; set; }

        public ArtistController():base(new ArtistService(new ArtistRepository(new Context())))
        {
          //ArtistService = new ArtistService(new ArtistRepository(new Context()));  
        }
    }
}