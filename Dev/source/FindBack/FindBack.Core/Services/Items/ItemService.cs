namespace FindBack.Core.Services.Items
{
    using System.Collections.Generic;

    using Cirrious.MvvmCross.Plugins.Messenger;

    using DataStore;

    public class ItemService : IItemService
    {
        private readonly IItemStorageService _itemStorageService;
        private readonly IMvxMessenger _messenger;

        public ItemService(IItemStorageService itemStorageService, IMvxMessenger messenger)
        {
            _itemStorageService = itemStorageService;
            _messenger = messenger;
        }

        public List<Item> GetItems()
        {
            return _itemStorageService.All();
        }

        public Item GetItem(int id)
        {
            return _itemStorageService.Get(id);
        }

        public void Add(Item item)
        {
            _itemStorageService.Add(item);
            PublishCollectionUpdate();
        }

        public void Update(Item item)
        {
            _itemStorageService.Update(item);
            PublishCollectionUpdate();
        }

        public void Delete(Item item)
        {
            _itemStorageService.Delete(item);
            PublishCollectionUpdate();
        }

        private void PublishCollectionUpdate()
        {
            _messenger.Publish(new CollectionChangedMessage(this));
        }

        public int Count {
            get
            {
                return _itemStorageService.Count;
            }
        }
    }
}