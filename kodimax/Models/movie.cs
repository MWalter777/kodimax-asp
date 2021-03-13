namespace kodimax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movie")]
    public partial class movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string timemovie { get; set; }

        [Required]
        [StringLength(100)]
        public string type { get; set; }

        [Required]
        [StringLength(500)]
        public string image { get; set; }
    }
}
