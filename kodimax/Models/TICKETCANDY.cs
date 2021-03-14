namespace kodimax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TICKETCANDY")]
    public partial class TICKETCANDY
    {
        [Key]
        public int ID_TIKET_CANDY { get; set; }

        public int? ID_CANDY { get; set; }
        public virtual CANDY candy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PAY { get; set; }
    }
}
