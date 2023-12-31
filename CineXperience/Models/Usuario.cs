﻿using CineXperience.Helpers;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CineXperience.Models
{
    public class Usuario : IdentityUser<int>
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
        public override string Email 
        {
            get { return base.Email; }
            set { base.Email = value; }
        }

    }
}
