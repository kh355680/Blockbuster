

using System.Collections.Generic;


namespace Blockbuster.MVC.Models.Entities
{
    public class Genre : Entity
    {        
        public string Name { get; set; }
        public virtual IEnumerable<Movie> Movies { get; set; }         
    }
}