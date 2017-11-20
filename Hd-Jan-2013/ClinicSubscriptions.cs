namespace Hd_Jan_2013
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClinicSubscriptions
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClinicId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubscriptionTypeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime RegisteredDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [Required]
        [StringLength(100)]
        public string ExtraText { get; set; }

        public bool? IsEconomic { get; set; }

        public virtual Clinics Clinics { get; set; }

        public virtual SubscriptionTypes SubscriptionTypes { get; set; }
    }
}
