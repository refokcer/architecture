namespace Lab5.Domain.Entities;

public sealed class PremiumUser(Guid id, string name) : LibraryUser(id, name)
{
    public override int MaxActiveRentals => 7;
}
