using CineXperience.Helpers;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CineXperience.Models
{
    public class Rol : IdentityRole<int>
    {
        [Display(Name = Displays.NameDisplay)]
        public override string Name 
        {
            get { return base.Name; }
            set { base.Name = value; } 
        }
        public override string NormalizedName
        {
            get => base.NormalizedName;
            set => base.NormalizedName = value;
        }
    }
}
