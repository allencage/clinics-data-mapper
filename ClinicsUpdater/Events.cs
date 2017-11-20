namespace ClinicsUpdater
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Events
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        [Required]
        [StringLength(100)]
        public string Token { get; set; }

        public int? ClinicId { get; set; }

        public int? CategoryId { get; set; }

        public string ExtraText { get; set; }
    }
}
