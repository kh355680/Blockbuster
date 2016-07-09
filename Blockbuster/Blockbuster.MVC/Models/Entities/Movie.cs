
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blockbuster.MVC.Models.Entities
{
    public class Movie : Entity
    {
        public string Name { get; set; }
        public string GenreId { get; set; }
        public string DirectorName { get; set; }
        public int ReleaseYear { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; } 
        public virtual IEnumerable<MovieCast> Casting { get; set; } 
    }
}