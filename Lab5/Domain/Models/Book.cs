namespace Lab5.Domain.Models;

public sealed class Book
{
    public Book(Guid id, string title, string author, int copiesTotal, int copiesAvailable)
    {
        if (copiesTotal < 0 || copiesAvailable < 0 || copiesAvailable > copiesTotal)
        {
            throw new ArgumentException("Invalid copies configuration.");
        }

        Id = id;
        Title = title;
        Author = author;
        CopiesTotal = copiesTotal;
        CopiesAvailable = copiesAvailable;
    }

    public Guid Id { get; }
    public string Title { get; }
    public string Author { get; }
    public int CopiesTotal { get; }
    public int CopiesAvailable { get; private set; }

    public bool IsAvailable => CopiesAvailable > 0;

    public bool TryRent()
    {
        if (!IsAvailable)
        {
            return false;
        }

        CopiesAvailable--;
        return true;
    }

    public void ReturnCopy()
    {
        if (CopiesAvailable < CopiesTotal)
        {
            CopiesAvailable++;
        }
    }
}
