using System;

namespace FindBack.Core.Services.Items
{
    using System.Collections.Generic;

    using Cirrious.MvvmCross.Plugins.Messenger;

    using FindBack.Core.Services.DataStore;

    public class ItemService : IItemService
    {
        private readonly IItemStorageService _itemStorageService;
        private readonly IMvxMessenger _messenger;

        public ItemService(IItemStorageService itemStorageService, IMvxMessenger messenger)
        {
            this._itemStorageService = itemStorageService;
            this._messenger = messenger;
        }

        public List<Item> GetItems()
        {
            //if (Count == 0)
            //{
            //    InitializeWithItems();
            //}

            return this._itemStorageService.All();
        }

        public Item GetItem(int id)
        {
            return this._itemStorageService.Get(id);
        }

        private void InitializeWithItems()
        {
            var item1 = new Item
                            {
                                Latitude = 47.063762,
                                Longitude = 8.311063,
                                Description = "Bike at work.",
                                ItemName = "CityBike Speedy",
                                ItemCreated = DateTime.Now
                            };
            var item2 = new Item
                             {
                                 Latitude = 47.030233,
                                 Longitude = 8.277813,
                                 Description = "Bike at Pilatus cable car station.",
                                 ItemName = "MountainBike Rocky",
                                 ItemCreated = DateTime.Now
                             };

            this.Add(item1);
            this.Add(item2);
        }

        public void Add(Item item)
        {
            this._itemStorageService.Add(item);
            this.PublishCollectionUpdate();
        }

        public void Update(Item item)
        {
            this._itemStorageService.Update(item);
            this.PublishCollectionUpdate();
        }

        public void Delete(Item item)
        {
            this._itemStorageService.Delete(item);
            this.PublishCollectionUpdate();
        }

        private void PublishCollectionUpdate()
        {
            this._messenger.Publish(new CollectionChangedMessage(this));
        }

        public int Count {
            get
            {
                return _itemStorageService.Count;
            }
        }
    }
}