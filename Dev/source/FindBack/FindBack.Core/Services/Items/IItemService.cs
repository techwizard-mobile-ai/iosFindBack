namespace FindBack.Core.Services.Items
{
    using System.Collections.Generic;

    using FindBack.Core.Services.DataStore;

    public interface IItemService
    {
        List<Item> GetItems();
        Item GetItem(int id);
        void Add(Item item);
        void Update(Item item);
        void Delete(Item item);
        int Count { get; }
    }
}