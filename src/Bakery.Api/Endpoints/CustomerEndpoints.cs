using Bakery.Database.Repositories;

namespace Bakery.Api.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/customers")
            .WithTags("Customers");

        group.MapGet("", CustomerHandlers.GetAllCustomers);
    }
}

public static class CustomerHandlers
{
    public static async Task<IResult> GetAllCustomers(
        CustomerRepository repository,
        CancellationToken cancellationToken)
    {
        var customers = await repository.GetAllCustomers();
        return Results.Ok(customers);
    }
}