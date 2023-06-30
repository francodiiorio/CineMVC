using CineXperience.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CineXperience.Models
{
    public class Funcion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = MsgError.Requerido)]
        public int SalaId { get; set; }
        public Sala Sala { get; set; }
        [Required(ErrorMessage = MsgError.Requerido)]
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        public int Precio { get; set; }

        public List<Entrada> movimientos { get; set; }
    }
}
