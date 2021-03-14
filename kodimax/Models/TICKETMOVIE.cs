namespace kodimax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TICKETMOVIE")]
    public partial class TICKETMOVIE
    {
        public int ID { get; set; }

        public int? ID_MOVIE { get; set; }

        public int? ID_SALA { get; set; }

        [Required]
        [StringLength(100)]
        public string SALA { get; set; }

        public int CANT_BUTACA { get; set; }

        [StringLength(100)]
        public string TYPE { get; set; }
    }
}
