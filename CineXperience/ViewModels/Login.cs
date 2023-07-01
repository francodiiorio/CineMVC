using CineXperience.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CineXperience.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = MsgError.Requerido)]
        [Display(Name = Displays.CorreoElectronico)]
        [EmailAddress(ErrorMessage = MsgError.NotValid)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = MsgError.StrMaxMin)]
        public string Email { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        [DataType(DataType.Password)]
        [Display(Name = Displays.Password)]
        public string Password { get; set; }

        public bool Recuerdame { get; set; }
    }
}
