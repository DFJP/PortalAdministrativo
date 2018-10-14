using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class RolesXUsuario
    {
        public int Id { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdRol { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }
    }
}