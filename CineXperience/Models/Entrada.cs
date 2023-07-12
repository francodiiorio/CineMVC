using CineXperience.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineXperience.Models
{
    public class Entrada
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        public int FuncionId { get; set;}
        public Funcion Funcion { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        [Range(1, Negocio.CantMax, ErrorMessage = MsgError.Range)]
        public int CantAsientos { get; set; }

        [Required(ErrorMessage = MsgError.Requerido)]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
