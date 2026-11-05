using Lainaamo.Models;

namespace Lainaamo.Repositories;

public interface IItemRepository
{
    List<Item> GetAll();
    Item? GetById(int id);
    Item Add(Item item);
}
