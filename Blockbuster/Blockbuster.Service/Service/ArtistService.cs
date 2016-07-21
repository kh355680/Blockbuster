using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;

namespace Blockbuster.Service.Service
{
    public class ArtistService : BaseService<Artist>
    {
        public ArtistService(ArtistRepository artistRepository) : base(artistRepository)
        {
            
        }
         
    }
}