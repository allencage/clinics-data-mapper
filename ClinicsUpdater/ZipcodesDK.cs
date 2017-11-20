namespace ClinicsUpdater
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ZipcodesDK")]
    public partial class ZipcodesDK
    {
        [Key]
        [StringLength(100)]
        public string Zipcode { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        public int AreaId { get; set; }

        public virtual Areas Areas { get; set; }
    }
}
