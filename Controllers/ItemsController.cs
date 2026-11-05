using Lainaamo.Exceptions;
using Lainaamo.Models;
using Lainaamo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lainaamo.Controllers;

[ApiController]
[Route("api/items")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public IActionResult GetItems()
    {
        return Ok(_itemService.GetAll());
    }

    [HttpPost]
    public IActionResult CreateItem(Item item)
    {
        try
        {
            Item created = _itemService.Create(item);
            return Created($"/api/items/{created.Id}", created);
        }
        catch (BusinessRuleException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
