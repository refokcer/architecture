namespace Lab5.Domain.Entities;

public sealed class Book
{
    public Book(Guid id, string title, string author, int totalCopies)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Book title is required.", nameof(title));
        }

        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException("Book author is required.", nameof(author));
        }

        if (totalCopies < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(totalCopies), "At least one copy is required.");
        }

        Id = id;
        Title = title;
        Author = author;
        TotalCopies = totalCopies;
    }

    public Guid Id { get; }
    public string Title { get; }
    public string Author { get; }
    public int TotalCopies { get; }
}
