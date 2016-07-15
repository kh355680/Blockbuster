
using System.Collections.Generic;

namespace Blockbuster.BusinessModel.Entities
{
    public class Artist : Entity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public IEnumerable<MovieCast> Movies { get; set; }        
    }
}
