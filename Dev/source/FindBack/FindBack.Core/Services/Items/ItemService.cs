namespace FindBack.Core.Services.Items
{
    using System.Collections.ObjectModel;
    using System.Linq;

    using Cirrious.MvvmCross.Plugins.Sqlite;

    using FindBack.Core.Model;

    public class ItemService : IItemService
    {
        private readonly ISQLiteConnection _connection;

        public ItemService(ISQLiteConnectionFactory factory)
        {
            _connection = factory.Create("findback.sql");
            _connection.CreateTable<Item>();
        }

        public ObservableCollection<Item> GetItems()
        {
            if (Count == 0)
            {
                InitializeWithItems();
            }

            return new ObservableCollection<Item>(this._connection.Table<Item>().ToList());
        }

        private void InitializeWithItems()
        {
            var item1 = new Item
                            {
                                Coordinates = "47.063762;8.311063",
                                Description = "Bike at work.",
                                ItemName = "CityBike Speedy"
                            };
            var item2 = new Item
                             {
                                 Coordinates = "47.030233;8.277813",
                                 Description = "Bike at Pilatus cable car station.",
                                 ItemName = "MountainBike Rocky"
                             };

            this.Insert(item1);
            this.Insert(item2);
        }

        public void Insert(Item item)
        {
            _connection.Insert(item);
        }

        public void Update(Item item)
        {
            _connection.Update(item);
        }

        public void Delete(Item item)
        {
            _connection.Delete(item);
        }

        public int Count {
            get
            {
                return _connection.Table<Item>().Count();
            }
        }
    }
}