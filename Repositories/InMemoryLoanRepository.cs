using Lainaamo.Models;

namespace Lainaamo.Repositories;

public class InMemoryLoanRepository : ILoanRepository
{
    private readonly List<Loan> _loans = new()
    {
        new Loan { Id = 1, ItemId = 2, BorrowerName = "Aino", BorrowedAt = DateTime.UtcNow.AddDays(-3) },
        new Loan { Id = 2, ItemId = 3, BorrowerName = "Elias", BorrowedAt = DateTime.UtcNow.AddDays(-10), ReturnedAt = DateTime.UtcNow.AddDays(-8) }
    };

    private int _nextId = 3;

    public List<Loan> GetAll()
    {
        return _loans;
    }

    public Loan? GetById(int id)
    {
        return _loans.FirstOrDefault(l => l.Id == id);
    }

    public Loan Add(Loan loan)
    {
        loan.Id = _nextId++;
        _loans.Add(loan);
        return loan;
    }
}
