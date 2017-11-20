namespace Hd_June_2011
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SubscriptionTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubscriptionTypes()
        {
            ClinicSubscriptions = new HashSet<ClinicSubscriptions>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool AutoAdd { get; set; }

        public bool Display { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int? DurationMonths { get; set; }

        public int MaxKeywords { get; set; }

        public int MaxAssociations { get; set; }

        public int MaxCategories { get; set; }

        public int Prominence { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicSubscriptions> ClinicSubscriptions { get; set; }
    }
}
