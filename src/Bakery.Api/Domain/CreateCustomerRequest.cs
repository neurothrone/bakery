using System.ComponentModel.DataAnnotations;

namespace Bakery.Api.Domain;

public record CreateCustomerRequest
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; init; }

    [Range(1, int.MaxValue)]
    public int StoreNumber { get; init; }

    [Required]
    [MaxLength(200)]
    public required string Address { get; init; }

    [Required]
    [MaxLength(10)]
    public required string PostalCode { get; init; }

    [Required]
    [MaxLength(100)]
    public required string City { get; init; }
}