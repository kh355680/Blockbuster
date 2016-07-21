
using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;

namespace Blockbuster.Repositories.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>
    {
        public ArtistRepository(Context context) : base(context)
        {
            
        }
    }
}
