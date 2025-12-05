using Bakery.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Data.Contexts;

public class BakeryDbContext(DbContextOptions<BakeryDbContext> options) : DbContext(options)
{
    public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
}