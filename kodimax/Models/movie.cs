namespace kodimax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MOVIE")]
    public partial class MOVIE
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }

        [Required]
        [StringLength(100)]
        public string TIME { get; set; }

        [Required]
        [StringLength(100)]
        public string TYPE { get; set; }

        [Required]
        [StringLength(500)]
        public string IMAGE { get; set; }
    }
}
