using System;
using System.Linq;
using System.Threading.Tasks;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.IRepositories;
using Blockbuster.Service.IService;

namespace Blockbuster.Service.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        public IBaseRepository<TEntity> Repository { get; set; } 

        public BaseService(IBaseRepository<TEntity> repository)
        {
            Repository = repository;
        } 

        public IQueryable<TEntity> Query()
        {
            return Repository.GetAll().AsQueryable();
        }

        public TEntity Find(string id)
        {
            return Repository.GetById(id);
        }

        public Task<bool> Insert(TEntity entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            return Repository.Insert(entity);
        }

        public Task<bool> Update(TEntity entity)
        {
            return Repository.Update(entity);
        }

        public Task<bool> Delete(string id)
        {
            return Repository.Remove(id);
        }

    }
}