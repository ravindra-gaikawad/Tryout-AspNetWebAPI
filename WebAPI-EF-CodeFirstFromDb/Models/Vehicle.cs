namespace WebAPI_EF_CodeFirstFromDb.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vehicle")]
    public partial class Vehicle : BaseEntity
    {
        // public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public byte Wheels { get; set; }

        public int Category { get; set; }
    }
}
