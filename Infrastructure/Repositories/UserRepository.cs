using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await context.Users.Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync(cancellationToken);
    }

    public async Task<User> Create(User user, CancellationToken cancellationToken)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User> Update(User user, CancellationToken cancellationToken)
    {
        context.Users.Update(user);

        await context.SaveChangesAsync();

        return user;
    }


    public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
    {
        var user = await GetById(id, cancellationToken);
        if (user == null) return false;

        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return true;
    }
}