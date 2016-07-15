
using System.ComponentModel.DataAnnotations.Schema;

namespace Blockbuster.BusinessModel.Entities
{
    public class MovieCast : Entity
    {
        public string MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public string ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }

        public string RoleName { get; set; }
    }
}
