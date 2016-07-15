
using System.ComponentModel.DataAnnotations;

namespace Blockbuster.BusinessModel.Entities
{
    public abstract class Entity
    {
        [Key]
        public string Id { get; set; }
    }
}
