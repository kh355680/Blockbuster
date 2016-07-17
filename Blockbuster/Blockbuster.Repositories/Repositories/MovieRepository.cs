
using System.Linq;
using System.Threading.Tasks;
using Blockbuster.BusinessModel;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.IRepositories;

namespace Blockbuster.Repositories.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public Context Context { get; set; }

        public MovieRepository()
        {
            Context = new Context();
        }
        public IQueryable<Movie> GetAll()
        {
            var movies = Context.Movies.AsQueryable();
            return movies;
        }

        public Movie GetById(string id)
        {
            var movie = Context.Movies.Find(id);
            return movie;
        }

        public async Task<bool> Insert(Movie movie)
        {
            Context.Movies.Add(movie);
            return await Save() > 0;
        }

        public async Task<bool> Update(Movie movie)
        {
            var originalData = GetById(movie.Id);

            if (originalData != null)
            {
                Context.Entry(originalData).CurrentValues.SetValues(movie);
            }

            return await Save() > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var movie = GetById(id);
            Context.Movies.Remove(movie);

            return await Save() > 0;
        }

        public async Task<int> Save()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
