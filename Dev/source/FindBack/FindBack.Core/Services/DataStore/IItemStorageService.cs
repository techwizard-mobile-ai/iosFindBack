namespace FindBack.Core.Services.DataStore
{
    using System.Collections.Generic;

    public interface IItemStorageService
    {
        List<Item> All();
        void Add(Item item);
        void Delete(Item item);
        void Update(Item item);
        Item Get(int id);
        int Count { get; }
    }
}