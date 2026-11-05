using Lainaamo.Models;

namespace Lainaamo.Repositories;

public interface ILoanRepository
{
    List<Loan> GetAll();
    Loan? GetById(int id);
    Loan Add(Loan loan);
}
