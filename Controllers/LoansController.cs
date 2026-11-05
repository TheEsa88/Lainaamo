using Lainaamo.Exceptions;
using Lainaamo.Models;
using Lainaamo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lainaamo.Controllers;

[ApiController]
[Route("api/loans")]
public class LoansController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoansController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet]
    public IActionResult GetLoans()
    {
        return Ok(_loanService.GetAll());
    }

    [HttpPost]
    public IActionResult Borrow(LoanRequest request)
    {
        try
        {
            Loan loan = _loanService.Borrow(request.ItemId, request.BorrowerName);
            return Created($"/api/loans/{loan.Id}", loan);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (BusinessRuleException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}/return")]
    public IActionResult ReturnLoan(int id)
    {
        try
        {
            return Ok(_loanService.Return(id));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (BusinessRuleException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
