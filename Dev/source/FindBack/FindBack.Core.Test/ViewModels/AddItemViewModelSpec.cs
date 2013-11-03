using System.Globalization;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.Plugins.PictureChooser;
using FakeItEasy;
using FindBack.Core.Services.DataStore;
using FindBack.Core.Services.Items;
using FindBack.Core.Services.Location;
using FindBack.Core.ViewModels;
using FluentAssertions;
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
        protected static IMvxFileStore fileStore;

        private Establish context = () =>
        {
            locationService = A.Fake<ILocationService>();
            messenger = A.Fake<IMvxMessenger>();
            pictureChooserTask = A.Fake<IMvxPictureChooserTask>();
            itemService = A.Fake<IItemService>();
            fileStore = A.Fake<IMvxFileStore>();
            testee = new AddItemViewModel(locationService, messenger, pictureChooserTask, itemService, fileStore);
        };
    }

    [Subject(typeof(AddItemViewModel))]
    public class when_saving_an_item : AddItemViewModelSpec
    {
        private Because of = () =>
        {
            testee.SaveCommand.Execute(null);
        };

        
    }
}