using Bakery.Database.Data;
using Bakery.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Database.Repositories;

public class CustomerRepository(BakeryDbContext dbContext)
{
    public Task<List<CustomerEntity>> GetAllCustomers()
    {
        return dbContext.Customers
            .AsNoTracking()
            .ToListAsync();
    }
}