
using System.Linq;
using System.Threading.Tasks;
using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.IRepositories;

namespace Blockbuster.Repositories.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        public Context Context { get; set; }

        public GenreRepository()
        {
            Context = new Context();
        }
        public IQueryable<Genre> GetList()
        {
            var genres = Context.Genres.AsQueryable();
            return genres;
        }

        public Genre GetById(string id)
        {
            var genre = Context.Genres.Find(id);
            return genre;
        }

        public async Task<bool> Insert(Genre genre)
        {
            var result = Context.Genres.Add(genre);

            if (result != null)
            {
                return await Save();
            }

            return false;
        }

        public async Task<bool> Update(Genre genre)
        {
            var original = await Context.Genres.FindAsync(genre.Id);

            if (original != null)
            {
                Context.Entry(original).CurrentValues.SetValues(genre);
                return await Save();
            }

            return false;
        }

        public async Task<bool> Delete(string id)
        {
            var genre = await Context.Genres.FindAsync(id);

            if (genre != null)
            {
                Context.Genres.Remove(genre);
            }

            return await Save();
        }

        public async Task<bool> Save()
        {
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
