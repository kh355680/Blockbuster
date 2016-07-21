using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;

namespace Blockbuster.Repositories.Repositories
{
    public class GenreRepository : BaseRepository<Genre>
    {
        public GenreRepository(Context context):base(context)
        {

        }
         
    }
}