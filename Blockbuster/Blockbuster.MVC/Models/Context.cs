
using System.Data.Entity;
using Blockbuster.MVC.Models.Entities;

namespace Blockbuster.MVC.Models
{
    public class Context : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }

        public Context() : base("DefaultConnection")
        {
            
        }
    }
}