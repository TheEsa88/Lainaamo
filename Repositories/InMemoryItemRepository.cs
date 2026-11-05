using Lainaamo.Models;

namespace Lainaamo.Repositories;

public class InMemoryItemRepository : IItemRepository
{
    private readonly List<Item> _items = new()
    {
        new Item { Id = 1, Name = "Salibandymaila" },
        new Item { Id = 2, Name = "Projektori" },
        new Item { Id = 3, Name = "HDMI-kaapeli" }
    };

    private int _nextId = 4;

    public List<Item> GetAll()
    {
        return _items;
    }

    public Item? GetById(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }

    public Item Add(Item item)
    {
        item.Id = _nextId++;
        _items.Add(item);
        return item;
    }
}
