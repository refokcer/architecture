using Lab5.Domain.Entities;
using Lab5.Domain.Interfaces;

namespace Lab5.Infrastructure.Repositories;

public sealed class InMemoryUserRepository : IUserRepository
{
    private readonly IReadOnlyCollection<LibraryUser> _users =
    [
        new StandardUser(Guid.Parse("00000000-0000-0000-0000-000000000201"), "Oksana"),
        new PremiumUser(Guid.Parse("00000000-0000-0000-0000-000000000202"), "Maksym")
    ];

    public LibraryUser? GetById(Guid id) => _users.FirstOrDefault(x => x.Id == id);
}
