namespace ClinicsUpdater
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StripeEventLogs
    {
        [StringLength(30)]
        public string Id { get; set; }

        public DateTime SentDate { get; set; }

        [Required]
        [StringLength(60)]
        public string Type { get; set; }
    }
}
