namespace Hd_Jan_2013
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Settings
    {
        [Key]
        [StringLength(100)]
        public string Token { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
