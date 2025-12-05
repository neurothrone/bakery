using Bakery.Data.Contexts;
using Bakery.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Data.Repositories;

public class CustomerRepository(BakeryDbContext dbContext)
{
    public Task<List<CustomerEntity>> GetAllCustomersAsync(
        CancellationToken cancellationToken = default)
    {
        return dbContext.Customers
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public Task<CustomerEntity?> GetCustomerByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return dbContext.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<CustomerEntity> CreateCustomerAsync(
        CustomerEntity customer,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Customers.AddAsync(customer, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return customer;
    }
}