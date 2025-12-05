using Bakery.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Database.Data;

public class BakeryDbContext(DbContextOptions<BakeryDbContext> options) : DbContext(options)
{
    public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
}