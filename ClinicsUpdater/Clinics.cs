namespace ClinicsUpdater
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
            Keywords = new HashSet<Keywords>();
            StripeLocalInvoices = new HashSet<StripeLocalInvoices>();
            Areas = new HashSet<Areas>();
            Clinics1 = new HashSet<Clinics>();
            Clinics2 = new HashSet<Clinics>();
            Categories = new HashSet<Categories>();
            Categories1 = new HashSet<Categories>();
        }

        public Clinics(Hd_June_2011.Clinics clinic)
        {
            Id = clinic.Id;
            UpdateTime = clinic.UpdateTime;
            Association = clinic.Association;
            Password = clinic.Password;
            AcceptedTerms = clinic.AcceptedTerms;
            ShortName = clinic.ShortName;
            Name = clinic.Name;
            Address = clinic.Address;
            Zipcode = clinic.Zipcode;

        }

        public int Id { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool Association { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public DateTime? AcceptedTerms { get; set; }

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

        [StringLength(100)]
        public string VatNumber { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [Required]
        [StringLength(100)]
        public string AdmEmail { get; set; }

        [StringLength(100)]
        public string PublicEmail { get; set; }

        [StringLength(100)]
        public string Homepage { get; set; }

        public string Description { get; set; }

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

        [Required]
        [StringLength(100)]
        public string InvoiceCountry { get; set; }

        public int DataQuality { get; set; }

        public string FreeKeywords { get; set; }

        public string PaidKeywords { get; set; }

        public Guid LoginGuid { get; set; }

        public bool Hidden { get; set; }

        [StringLength(500)]
        public string StripeCustomerId { get; set; }

        public DateTime? CreditCardExpires { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicSubscriptions> ClinicSubscriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persons> Persons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Keywords> Keywords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StripeLocalInvoices> StripeLocalInvoices { get; set; }

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
