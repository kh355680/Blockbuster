
using System.Linq;
using System.Threading.Tasks;
using Blockbuster.BusinessModel.Entities;

namespace Blockbuster.Service.IService
{
    public interface IGenreService
    {
        IQueryable<Genre> GetAll();
        Genre GetById(string id);
        Task<bool> Insert(Genre genre);
        Task<bool> Update(Genre genre);
        Task<bool> Remove(string id);
    }
}
