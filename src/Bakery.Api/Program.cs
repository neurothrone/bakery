using Bakery.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapCustomerEndpoints();

app.Run();