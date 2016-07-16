
using System.Linq;
using System.Threading.Tasks;
using Blockbuster.BusinessModel.Entities;
using Blockbuster.Repositories.IRepositories;
using Blockbuster.Repositories.Repositories;
using Blockbuster.Service.IService;

namespace Blockbuster.Service.Service
{
    public class GenreService : IGenreService
    {
        public IGenreRepository Repository { get; set; }

        public GenreService()
        {
            Repository = new GenreRepository();
        }
        public IQueryable<Genre> GetAll()
        {
            var genres = Repository.GetList().AsQueryable();
            return genres;
        }

        public Genre GetById(string id)
        {
            var genre = Repository.GetById(id);
            return genre;
        }

        public async Task<bool> Insert(Genre genre)
        {
            return await Repository.Insert(genre);
        }

        public async Task<bool> Update(Genre genre)
        {
            return await Repository.Update(genre);
        }

        public async Task<bool> Remove(string id)
        {
            return await Repository.Delete(id);
        }
    }
}
