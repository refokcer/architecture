using Lab5.Domain.Abstractions;
using Lab5.Domain.Models;

namespace Lab5.Infrastructure.Repositories;

public sealed class InMemoryUserAccountRepository : IUserAccountRepository
{
    private readonly List<UserAccount> _users;

    public InMemoryUserAccountRepository(IEnumerable<UserAccount> seed)
    {
        _users = seed.ToList();
    }

    public UserAccount? GetById(Guid id) => _users.FirstOrDefault(u => u.Id == id);

    public IReadOnlyCollection<UserAccount> GetAll() => _users;

    public void Add(UserAccount account) => _users.Add(account);

    public void Update(UserAccount account)
    {
        // In-memory storage keeps references, method is explicit for abstraction completeness.
    }
}
