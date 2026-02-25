using Lab5.Domain.Abstractions;
using Lab5.Domain.Models;

namespace Lab5.Application.Services;

public sealed class UserAccountService(IUserAccountRepository userRepository)
{
    public IReadOnlyCollection<UserAccount> GetAll() => userRepository.GetAll();

    public UserAccount Create(string name, bool premium)
    {
        UserAccount account = premium
            ? new PremiumUserAccount(Guid.NewGuid(), name)
            : new StandardUserAccount(Guid.NewGuid(), name);

        userRepository.Add(account);
        return account;
    }

    public bool SetActive(Guid userId, bool isActive)
    {
        var user = userRepository.GetById(userId);
        if (user is null)
        {
            return false;
        }

        if (isActive)
        {
            user.Activate();
        }
        else
        {
            user.Deactivate();
        }

        userRepository.Update(user);
        return true;
    }
}
