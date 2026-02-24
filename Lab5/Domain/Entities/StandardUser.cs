namespace Lab5.Domain.Entities;

public sealed class StandardUser(Guid id, string name) : LibraryUser(id, name)
{
    public override int MaxActiveRentals => 3;
}
