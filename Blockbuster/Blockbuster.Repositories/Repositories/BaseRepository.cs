using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.IRepositories;

namespace Blockbuster.Repositories.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        public Context Context { get; set; }
        public DbSet<TEntity> Table { get; set; } 

        public BaseRepository()
        {
            Context = new Context();
            Table = Context.Set<TEntity>();
        } 

        public IQueryable<TEntity> GetAll()
        {
            return Table.AsQueryable();
        }

        public TEntity GetById(string id)
        {
            var entity  = Table.Find(id);
            return entity;
        }

        public async Task<bool> Insert(TEntity entity)
        {
            Table.Add(entity);
            return await Save();
        }

        public async Task<bool> Update(TEntity entity)
        {
            var original = await Table.FindAsync(entity.Id);

            if (original != null)
            {
                Context.Entry(original).CurrentValues.SetValues(entity); 
            }
            return await Save();
        }

        public async Task<bool> Remove(string id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                Table.Remove(entity);
            }

            return await Save();
        }

        public async Task<bool> Save()
        {
            return await Context.SaveChangesAsync() > 0;
        }
    }
}