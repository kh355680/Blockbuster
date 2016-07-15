
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blockbuster.BusinessModel.Entities
{
    public class Movie : Entity
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public int ReleaseYear { get; set; }


        // Navigation Properties
        public string GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public IEnumerable<MovieCast> Casting { get; set; } 
    }
}
