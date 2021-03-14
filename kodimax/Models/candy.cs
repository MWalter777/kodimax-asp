namespace kodimax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CANDY")]
    public partial class CANDY
    {
        [Key]
        public int ID_CANDY { get; set; }

        [StringLength(100)]
        public string NAME { get; set; }

        [StringLength(100)]
        public string TYPE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PRICE { get; set; }

        [StringLength(500)]
        public string IMAGE { get; set; }
    }
}
