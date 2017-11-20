namespace Hd_June_2011
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clinics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clinics()
        {
            ClinicSubscriptions = new HashSet<ClinicSubscriptions>();
            Persons = new HashSet<Persons>();
            Areas = new HashSet<Areas>();
            Clinics1 = new HashSet<Clinics>();
            Clinics2 = new HashSet<Clinics>();
            Categories = new HashSet<Categories>();
            Categories1 = new HashSet<Categories>();
        }

        public int Id { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool Association { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public DateTime? AcceptedTerms { get; set; }

        [Required]
        [StringLength(30)]
        public string ShortName { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Zipcode { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(100)]
        public string VatNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string AdmEmail { get; set; }

        [Required]
        [StringLength(100)]
        public string PublicEmail { get; set; }

        [Required]
        [StringLength(100)]
        public string Homepage { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(200)]
        public string InvoiceName { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceCity { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceZipcode { get; set; }

        [StringLength(100)]
        public string InvoiceCountry { get; set; }

        public int DataQuality { get; set; }

        [Required]
        public string FreeKeywords { get; set; }

        [Required]
        public string PaidKeywords { get; set; }

        public Guid LoginGuid { get; set; }

        public bool Hidden { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicSubscriptions> ClinicSubscriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persons> Persons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Areas> Areas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clinics> Clinics1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clinics> Clinics2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Categories> Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Categories> Categories1 { get; set; }
    }
}
