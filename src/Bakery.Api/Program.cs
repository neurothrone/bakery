using Bakery.Api.Endpoints;
using Bakery.Database.Data;
using Bakery.Database.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BakeryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<CustomerRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapCustomerEndpoints();

app.Run();