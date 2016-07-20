using System.Linq;
using System.Threading.Tasks;
using Blockbuster.BusinessModel.Entities;

namespace Blockbuster.Repositories.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(string id);
        Task<bool> Insert(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Remove(string id);
        Task<bool> Save();

    }
}