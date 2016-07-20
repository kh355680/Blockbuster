using System.Linq;
using System.Threading.Tasks;
using Blockbuster.BusinessModel.Entities;

namespace Blockbuster.Service.IService
{
    public interface IBaseService<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Query();
        TEntity Find(string id);
        Task<bool> Insert(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(string id);

    }
}