using Lab5.Domain.Models;

namespace Lab5.Domain.Abstractions;

public interface IUserAccountRepository
{
    UserAccount? GetById(Guid id);
    IReadOnlyCollection<UserAccount> GetAll();
    void Add(UserAccount account);
    void Update(UserAccount account);
}
