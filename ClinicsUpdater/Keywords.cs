namespace ClinicsUpdater
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Keywords
    {
        public int Id { get; set; }

        public int ClinicId { get; set; }

        [Required]
        [StringLength(250)]
        public string Value { get; set; }

        public virtual Clinics Clinics { get; set; }
    }
}
