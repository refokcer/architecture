namespace Lab5.Domain.Entities;

public abstract class LibraryUser
{
    protected LibraryUser(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("User name is required.", nameof(name));
        }

        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }

    public abstract int MaxActiveRentals { get; }
}
