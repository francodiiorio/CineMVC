using CineXperience.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CineXperience.Models
{
    public class Sala
    {
        [Display(Name = Displays.SalaNumber)]
        public int Id { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        public int Capacidad { get; set; }

    }
}
