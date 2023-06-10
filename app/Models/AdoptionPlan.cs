using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourAppNamespace.Models
{
    public class AdoptionPlan
    {
        [Key]
        public int Id { get; set; }

        public int AnimalId { get; set; }

        public int UserId { get; set; }

        public string AdopterName { get; set; }

        public string AdopterEmail { get; set; }

        [ForeignKey("AnimalId")]
        public virtual Animal Animal { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
