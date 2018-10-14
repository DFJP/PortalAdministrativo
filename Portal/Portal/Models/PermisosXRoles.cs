using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class PermisosXRoles
    {
        public int Id { get; set; }
        [Required]
        public int IdRol { get; set; }
        [Required]
        public int IdPermiso { get; set; }
        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }
        [ForeignKey("IdPermiso")]
        public Permiso Permiso { get; set; }
    }
}