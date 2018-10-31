namespace WebAPI_EF_CodeFirstFromDb.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Manufacturer")]
    public partial class Manufacturer : BaseEntity
    {
        // [Key]
        // [Column(Order = 0)]
        // public override int Id { get; set; }
        [StringLength(50)]
        public string ManufacturerName { get; set; }
    }
}
