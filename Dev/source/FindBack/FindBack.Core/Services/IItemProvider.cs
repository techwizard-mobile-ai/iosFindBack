namespace FindBack.Core.Services
{
    using System.Collections.ObjectModel;

    using FindBack.Core.Model;

    public interface IItemProvider
    {
        ObservableCollection<Item> GetItems();
    }
}