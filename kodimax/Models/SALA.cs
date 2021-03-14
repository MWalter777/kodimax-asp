namespace kodimax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SALA")]
    public partial class SALA
    {
        [Key]
        public int ID_SALA { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PRICE { get; set; }

        public int QUANTIY { get; set; }
    }
}
