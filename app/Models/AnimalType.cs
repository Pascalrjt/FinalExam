using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourAppNamespace.Models
{
    public class AnimalType
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}

