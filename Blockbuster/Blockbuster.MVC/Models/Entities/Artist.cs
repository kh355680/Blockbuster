
using System.Collections.Generic;

namespace Blockbuster.MVC.Models.Entities
{
    public class Artist : Entity
    {
        public string Name { get; set; }
        public IEnumerable<MovieCast> ActedMovies { get; set; } 
       
    }
}