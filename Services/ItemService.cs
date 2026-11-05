using Lainaamo.Exceptions;
using Lainaamo.Models;
using Lainaamo.Repositories;

namespace Lainaamo.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _items;

    public ItemService(IItemRepository items)
    {
        _items = items;
    }

    public List<Item> GetAll()
    {
        return _items.GetAll();
    }

    public Item Create(Item item)
    {
        if (string.IsNullOrWhiteSpace(item.Name))
        {
            throw new BusinessRuleException("Välineen nimi on pakollinen.");
        }

        return _items.Add(item);
    }
}
