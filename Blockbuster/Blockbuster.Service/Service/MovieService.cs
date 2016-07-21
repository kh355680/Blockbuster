using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;

namespace Blockbuster.Service.Service
{
    public class MovieService : BaseService<Movie>
    {
        public MovieService(MovieRepository movieRepository):base(movieRepository)
        {
            
        }
    }
}