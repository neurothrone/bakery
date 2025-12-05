using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakery.Database.Entities;

[Table("customers")]
public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Range(1, int.MaxValue)]
    public int StoreNumber { get; set; }

    [Required]
    [MaxLength(200)]
    public required string Address { get; set; }

    [Required]
    [MaxLength(10)]
    public required string PostalCode { get; set; }

    [Required]
    [MaxLength(100)]
    public required string City { get; set; }
}