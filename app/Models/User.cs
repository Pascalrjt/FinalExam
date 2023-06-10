using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace YourAppNamespace.Models
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        public virtual ICollection<AdoptionPlan> AdoptionPlans { get; set; }
    }
}
