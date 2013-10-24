namespace FindBack.Core.Services.DataStore
{
    using System.Collections.Generic;
    using System.Linq;

    using Cirrious.MvvmCross.Plugins.Sqlite;

    public class ItemStorageService : IItemStorageService
    {
        private ISQLiteConnection _connection;

        public ItemStorageService(ISQLiteConnectionFactory factory)
        {
            _connection = factory.Create("findback.sql");
            _connection.CreateTable<Item>();
        }

        public List<Item> All()
        {
            return _connection
                .Table<Item>()
                .OrderByDescending(x => x.ItemCreated)
                .ToList();
        }

        public Item Latest { get; private set; }

        public void Add(Item item)
        {
            _connection.Insert(item);
        }

        public void Delete(Item item)
        {
            _connection.Delete(item);
        }

        public void Update(Item item)
        {
            _connection.Update(item);
        }

        public Item Get(int id)
        {
            return _connection.Get<Item>(id);
        }

        public int Count
        {
            get
            {
                return _connection.Table<Item>().Count();
            }
        }
    }
}