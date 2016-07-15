
using System.Collections.Generic;

namespace Blockbuster.BusinessModel.Entities
{
    public class Genre : Entity
    {
        public string Name { get; set; }

        // Navigation Properties
        public IEnumerable<Movie> Movies  { get; set; }
    }
}
