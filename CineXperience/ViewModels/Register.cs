using CineXperience.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CineXperience.ViewModels
{
    public class Register
    {
        [Required(ErrorMessage = MsgError.Requerido)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = MsgError.StrMaxMin)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = MsgError.StrMaxMin)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        [Range(20000000, 200000000, ErrorMessage = MsgError.Range)]
        public int Dni { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        [Display(Name = Displays.CorreoElectronico)]
        [EmailAddress(ErrorMessage = MsgError.NotValid)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = MsgError.StrMaxMin)]
        public string Email { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        [DataType(DataType.Password)]
        [Display(Name = Displays.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        [DataType(DataType.Password)]
        [Display(Name = Displays.ConfirmPassword)]
        [Compare("Password", ErrorMessage = MsgError.PasswordMissmatch)]
        public string ConfirmPassword { get; set; }
    }
}
