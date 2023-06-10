using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourAppNamespace.Models
{
    public class Center
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
