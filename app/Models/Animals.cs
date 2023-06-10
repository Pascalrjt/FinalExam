using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourAppNamespace.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("AnimalType")]
        public int AnimalTypeId { get; set; }
        public virtual AnimalType AnimalType { get; set; }

        public string Breed { get; set; }
        
        public int Age { get; set; }

        [ForeignKey("Center")]
        public int CenterId { get; set; }
        public virtual Center Center { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }
}
