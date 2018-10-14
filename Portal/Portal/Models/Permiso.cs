using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class Permiso
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string PermisoName { get; set; }
        [StringLength(500)]
        public string Descripcion { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}