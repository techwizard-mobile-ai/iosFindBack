namespace FindBack.Core.Services.DataStore
{
    using System.Collections.Generic;

    public interface IItemStorageService
    {
        List<Item> All();
        Item Latest { get; }
        void Add(Item item);
        void Delete(Item item);
        void Update(Item item);
        Item Get(int id);
        int Count { get; }
    }
}