namespace Hd_Jan_2013
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Persons
    {
        public int Id { get; set; }

        public int ClinicId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string CellPhone { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public virtual Clinics Clinics { get; set; }
    }
}
