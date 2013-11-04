using System;
using System.Linq;
using System.Linq.Expressions;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.Plugins.PictureChooser;
using FakeItEasy;
using FindBack.Core.Services.DataStore;
using FindBack.Core.Services.Items;
using FindBack.Core.Services.Location;
using FindBack.Core.ViewModels;
using Machine.Specifications;

namespace FindBack.Core.Test.ViewModels
{
    public class AddItemViewModelSpec : ViewModelSpecHelper
    {
        protected static AddItemViewModel testee;
        protected static ILocationService locationService;
        protected static IMvxMessenger messenger;
        protected static IMvxPictureChooserTask pictureChooserTask;
        protected static IItemService itemService;
        protected static IImageStorageService imageStore;

        private Establish context = () =>
        {
            locationService = A.Fake<ILocationService>();
            messenger = A.Fake<IMvxMessenger>();
            pictureChooserTask = A.Fake<IMvxPictureChooserTask>();
            itemService = A.Fake<IItemService>();
            imageStore = A.Fake<IImageStorageService>();
            testee = new AddItemViewModel(locationService, messenger, pictureChooserTask, itemService, imageStore);
        };
    }

    [Subject(typeof(AddItemViewModel))]
    public class when_saving_an_item : AddItemViewModelSpec
    {
        const string ItemName = "ItemName";
        const string Description = "Description";
        const double Latitude = 47.063762;
        const double Longitude = 8.311063;
        const string SaveLocation = "SaveLocation";
        static readonly byte[] PictureBytes = {0x43};

        private static Expression<Func<Item, bool>> ItemEquality()
        {
            return x => x.ItemName == ItemName &&
                        x.Description == Description &&
                        x.Latitude == Latitude &&
                        x.Longitude == Longitude &&
                        x.ImagePath == SaveLocation;
        }

        Establish context = () =>
        {
            testee.ItemName = ItemName;
            testee.Description = Description;
            testee.Latitude = Latitude;
            testee.Longitude = Longitude;
            testee.PictureBytes = PictureBytes;

            A.CallTo(() => imageStore.SaveImageToFile(A<byte[]>._)).Returns(SaveLocation);
        };

        Because of = () => testee.SaveCommand.Execute(null);

        It should_save_the_item_with_correct_values = () =>
        {
            A.CallTo(() => itemService.Add(A<Item>.That.Matches(ItemEquality()))).MustHaveHappened();
        };

        It should_save_the_picture_to_the_filesystem = () =>
        {
            A.CallTo(
                () =>
                    imageStore.SaveImageToFile(A<byte[]>.That.Matches(x => x.SequenceEqual(PictureBytes)))).MustHaveHappened();
        };
    }
}