using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace kodimax.Models
{

    [Table("ROL")]
    public partial class ROL
    {
        [Key]
        public int ID_ROL { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE_ROL { get; set; }

        [Required]
        [StringLength(150)]
        public string DESCRIPCION_ROL { get; set; }
    }
}