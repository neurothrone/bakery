using Bakery.Data.Entities;

namespace Bakery.Api.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app
            .MapGroup("/customers")
            .WithTags("Customers");

        group.MapGet("", CustomerHandlers.GetAllCustomersAsync)
            .WithSummary("Get all Customers")
            .WithDescription("Get all Customers")
            .Produces<List<CustomerEntity>>();

        group.MapGet("/{id:int:min(0)}", CustomerHandlers.GetCustomerByIdAsync)
            .WithSummary("Get Customer by Id")
            .WithDescription("Get Customer by Id")
            .Produces<CustomerEntity>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("", CustomerHandlers.CreateCustomerAsync)
            .WithSummary("Create Customer")
            .WithDescription("Create Customer")
            .Produces<CustomerEntity>()
            .Produces(StatusCodes.Status400BadRequest);
    }
}