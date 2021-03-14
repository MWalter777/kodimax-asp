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
        [Key]
        public int ID { get; set; }

        public int? ID_MOVIE { get; set; }
        public virtual MOVIE movie { get; set; }

        public int? ID_SALA { get; set; }
        public virtual SALA sala { get; set; }

        public int CANT_BUTACA { get; set; }

        [StringLength(100)]
        public string TYPE { get; set; }
    }
}
