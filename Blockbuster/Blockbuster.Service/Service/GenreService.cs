using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;

namespace Blockbuster.Service.Service
{
    public class GenreService : BaseService<Genre>
    {
        public GenreService(GenreRepository genreRepository):base(genreRepository)
        {
            
        }
    }
}