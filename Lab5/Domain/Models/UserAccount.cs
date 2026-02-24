namespace Lab5.Domain.Models;

public abstract class UserAccount
{
    protected UserAccount(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }
    public bool IsActive { get; private set; } = true;

    public abstract int MaxRentedBooks { get; }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}

public sealed class StandardUserAccount(Guid id, string name) : UserAccount(id, name)
{
    public override int MaxRentedBooks => 3;
}

public sealed class PremiumUserAccount(Guid id, string name) : UserAccount(id, name)
{
    public override int MaxRentedBooks => 7;
}
