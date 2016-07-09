
using System.ComponentModel.DataAnnotations;

namespace Blockbuster.MVC.Models.Entities
{
    public abstract class Entity
    {
        [Key]
        public string Id { get; set; }
    }
}