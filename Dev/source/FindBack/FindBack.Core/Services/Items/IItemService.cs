namespace FindBack.Core.Services.Items
{
    using System.Collections.ObjectModel;

    using FindBack.Core.Model;

    public interface IItemService
    {
        ObservableCollection<Item> GetItems();
        void Insert(Item item);
        void Update(Item item);
        void Delete(Item item);
        int Count { get; }
    }
}