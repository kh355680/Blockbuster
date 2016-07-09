
using System.ComponentModel.DataAnnotations.Schema;

namespace Blockbuster.MVC.Models.Entities
{
    public class MovieCast : Entity
    {
        public string ArtistId { get; set; }
        public string MovieId { get; set; }

        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
    }
}