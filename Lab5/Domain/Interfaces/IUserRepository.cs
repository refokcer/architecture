using Lab5.Domain.Entities;

namespace Lab5.Domain.Interfaces;

public interface IUserRepository
{
    LibraryUser? GetById(Guid id);
}
