using Lainaamo.Models;

namespace Lainaamo.Services;

public interface IItemService
{
    List<Item> GetAll();
    Item Create(Item item);
}
