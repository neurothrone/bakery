using Bakery.Api.Domain;
using Bakery.Data.Entities;
using Bakery.Data.Repositories;

namespace Bakery.Api.Endpoints;

public static class CustomerHandlers
{
    public static async Task<IResult> GetAllCustomersAsync(
        CustomerRepository repository,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var customers = await repository.GetAllCustomersAsync(cancellationToken);
            return TypedResults.Ok(customers);
        }
        catch (Exception ex)
        {
            return TypedResults.InternalServerError(ex);
        }
    }

    public static async Task<IResult> GetCustomerByIdAsync(
        int id,
        CustomerRepository repository,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var customer = await repository.GetCustomerByIdAsync(id, cancellationToken);
            return customer is not null
                ? TypedResults.Ok(customer)
                : TypedResults.NotFound();
        }
        catch (Exception ex)
        {
            return TypedResults.InternalServerError(ex);
        }
    }

    public static async Task<IResult> CreateCustomerAsync(
        CreateCustomerRequest request,
        CustomerRepository repository,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = new CustomerEntity
            {
                Name = request.Name,
                StoreNumber = request.StoreNumber,
                Address = request.Address,
                PostalCode = request.PostalCode,
                City = request.City
            };
            var createdEntity = await repository.CreateCustomerAsync(entity, cancellationToken);
            return TypedResults.Created($"/customers/{createdEntity.Id}", createdEntity);
        }
        catch (Exception ex)
        {
            return TypedResults.InternalServerError(ex);
        }
    }
}