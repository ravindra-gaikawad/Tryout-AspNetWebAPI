namespace WebAPI_EF_CodeFirstFromDb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manufacturer")]
    public partial class Manufacturer
    {
        [Key]
        [Column(Order = 0)]
        public int ManufacturerId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ManufacturerName { get; set; }
    }
}
