
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockbuster.BusinessModel.Entities;

namespace Blockbuster.Repositories.IRepositories
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetAll();
        Movie GetById(string id);
        Task<bool> Insert(Movie movie);
        Task<bool> Update(Movie movie);
        Task<bool> Delete(string id);
        Task<int> Save();

    }   
}
