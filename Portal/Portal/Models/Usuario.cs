using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }
    }
}