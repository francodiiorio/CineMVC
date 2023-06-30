using CineXperience.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CineXperience.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        [Range(40, 240, ErrorMessage = MsgError.Range)]
        public int Duracion { get; set; }
        public string Director { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        public Genero Genero { get; set; }
        public string Foto { get; set; }
    }
}
