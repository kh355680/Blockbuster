using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;

namespace Blockbuster.Repositories.Repositories
{
    public class MovieRepository : BaseRepository<Movie>
    {
        public MovieRepository(Context context):base(context)
        {
            
        }
    }
}