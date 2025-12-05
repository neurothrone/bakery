using Bakery.Data.Contexts;
using Bakery.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Data.Repositories;

public class CustomerRepository(BakeryDbContext dbContext)
{
    public Task<List<CustomerEntity>> GetAllCustomers()
    {
        return dbContext.Customers
            .AsNoTracking()
            .ToListAsync();
    }
}