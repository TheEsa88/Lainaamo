using Lainaamo.Models;

namespace Lainaamo.Services;

public interface ILoanService
{
    List<Loan> GetAll();
    Loan Borrow(int itemId, string borrowerName);
    Loan Return(int id);
}
