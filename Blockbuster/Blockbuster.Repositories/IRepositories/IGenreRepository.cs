

using System.Linq;
using System.Threading.Tasks;
using Blockbuster.BusinessModel.Entities;

namespace Blockbuster.Repositories.IRepositories
{
    public interface IGenreRepository
    {
        IQueryable<Genre> GetList();
        Genre GetById(string id);
        Task<bool> Insert(Genre genre);
        Task<bool> Update(Genre genre);
        Task<bool> Delete(string id);             
        Task<bool> Save();
    }
}
