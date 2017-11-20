namespace ClinicsUpdater
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StripeLocalInvoices
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string StripeId { get; set; }

        public int ClinicId { get; set; }

        public virtual Clinics Clinics { get; set; }
    }
}
