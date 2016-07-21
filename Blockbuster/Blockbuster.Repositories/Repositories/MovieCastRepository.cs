using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;

namespace Blockbuster.Repositories.Repositories
{
    public class MovieCastRepository : BaseRepository<MovieCast>
    {
        public MovieCastRepository(Context context):base(context)
        {
            Context = context;
        }
    }
}