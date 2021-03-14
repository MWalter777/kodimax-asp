using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace kodimax.Models
{

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [Key]
        public int ID_USUARIO { get; set; }

        public int? ID_ROL { get; set; }

        [Required]
        [StringLength(60)]
        [EmailAddress]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(60)]
        public string PASSWORD { get; set; }

        [Required]
        [StringLength(60)]
        public string USERNAME { get; set; }

        [StringLength(60)]
        public string Imagen { get; set; }

        public bool? HABILITADO { get; set; }
    }
}