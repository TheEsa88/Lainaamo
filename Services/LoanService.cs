using Lainaamo.Exceptions;
using Lainaamo.Models;
using Lainaamo.Repositories;

namespace Lainaamo.Services;

public class LoanService : ILoanService
{
    private readonly IItemRepository _items;
    private readonly ILoanRepository _loans;

    public LoanService(IItemRepository items, ILoanRepository loans)
    {
        _items = items;
        _loans = loans;
    }

    public List<Loan> GetAll()
    {
        return _loans.GetAll();
    }

    public Loan Borrow(int itemId, string borrowerName)
    {
        if (_items.GetById(itemId) == null)
        {
            throw new NotFoundException("Välinettä ei löydy.");
        }

        if (string.IsNullOrWhiteSpace(borrowerName))
        {
            throw new BusinessRuleException("Lainaajan nimi on pakollinen.");
        }

        if (_loans.GetAll().Any(l => l.ItemId == itemId && l.ReturnedAt is null))
        {
            throw new BusinessRuleException("Väline on jo lainassa.");
        }

        Loan loan = new()
        {
            ItemId = itemId,
            BorrowerName = borrowerName,
            BorrowedAt = DateTime.UtcNow
        };

        return _loans.Add(loan);
    }

    public Loan Return(int id)
    {
        Loan? loan = _loans.GetById(id);

        if (loan == null)
        {
            throw new NotFoundException("Lainaa ei löydy.");
        }

        if (loan.ReturnedAt is not null)
        {
            throw new BusinessRuleException("Lainaa on jo palautettu.");
        }

        loan.ReturnedAt = DateTime.UtcNow;
        return loan;
    }
}