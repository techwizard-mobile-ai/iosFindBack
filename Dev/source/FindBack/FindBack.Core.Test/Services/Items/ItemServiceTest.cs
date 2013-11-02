using Cirrious.MvvmCross.Plugins.Messenger;
using FakeItEasy;
using FindBack.Core.Services.DataStore;
using FindBack.Core.Services.Items;
using NUnit.Framework;

namespace FindBack.Core.Test.Services.Items
{
    [TestFixture]
    public class ItemServiceTest
    {
        private IItemService testee;
        private IItemStorageService storageService;
        private IMvxMessenger messenger;

        [SetUp]
        public void SetUp()
        {
            this.storageService = A.Fake<IItemStorageService>();
            this.messenger = A.Fake<IMvxMessenger>();
            this.testee = new ItemService(this.storageService, this.messenger);
        }

        [Test]
        public void AddItem_ShouldAddToStorageAndPublishCollectionChange()
        {
            var item = new Item {ItemName = "Name"};
            this.testee.Add(item);

            A.CallTo(() => storageService.Add(item)).MustHaveHappened();
            A.CallTo(() => messenger.Publish(A<CollectionChangedMessage>._)).MustHaveHappened();
        }

        [Test]
        public void DeleteItem_ShouldDeleteFromStorageAndPublishCollectionChange()
        {
            var item = new Item {ItemName = "Name"};
            this.testee.Delete(item);

            A.CallTo(() => storageService.Delete(item)).MustHaveHappened();
            A.CallTo(() => messenger.Publish(A<CollectionChangedMessage>._)).MustHaveHappened();
        }

        [Test]
        public void UpdateItem_ShouldUpdateToStorageAndPublishCollectionChange()
        {
            var item = new Item {ItemName = "Name"};
            this.testee.Update(item);

            A.CallTo(() => storageService.Update(item)).MustHaveHappened();
            A.CallTo(() => messenger.Publish(A<CollectionChangedMessage>._)).MustHaveHappened();
        }

        [Test]
        public void GetItems_ShouldGetItemsFromStorage()
        {
            this.testee.GetItems();

            A.CallTo(() => storageService.All()).MustHaveHappened();
        }
    }
}