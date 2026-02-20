namespace Domain.Lends.Entities;

public class Lend
{
    public Guid Id { get; private set; }
    public string BorrowerName { get; set; } = string.Empty;
    public decimal Amount { get; private set; }
    public DateTime LendDate { get; private set; }
    public DateTime? DueDate { get; private set; }
    public bool IsReturned { get; private set; }

    private Lend() { }

// Adding guard clauses ensures our domain object is never in an invalid state.
   public Lend(string borrowerName, decimal amount, DateTime lendDate, DateTime? dueDate)
    {
        // Guard Clauses
        if (string.IsNullOrWhiteSpace(borrowerName))
            throw new ArgumentException("Borrower name cannot be empty.", nameof(borrowerName));
        
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");

        if (dueDate.HasValue && dueDate < lendDate)
            throw new ArgumentException("Due date cannot be in the past.", nameof(dueDate));

        Id = Guid.NewGuid();
        BorrowerName = borrowerName;
        Amount = amount;
        LendDate = lendDate;
        DueDate = dueDate;
        IsReturned = false;
    }

    public void MarkAsReturned()
    {
        if (IsReturned) return; // Idempotency: prevents logic from running twice
        IsReturned = true;
    }
}
   
