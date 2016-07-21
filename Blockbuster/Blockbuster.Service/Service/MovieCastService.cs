using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.Repositories;

namespace Blockbuster.Service.Service
{
    public class MovieCastService : BaseService<MovieCast>
    {
        public MovieCastService(MovieCastRepository movieCastRepository):base(movieCastRepository)
        {
            
        }
    }
}