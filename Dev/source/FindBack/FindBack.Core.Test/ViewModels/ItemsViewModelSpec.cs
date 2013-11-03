using System.Globalization;
using Cirrious.MvvmCross.Plugins.Messenger;
using FakeItEasy;
using FindBack.Core.Services.DataStore;
using FindBack.Core.Services.Items;
using FindBack.Core.ViewModels;
using FluentAssertions;
using Machine.Specifications;

namespace FindBack.Core.Test.ViewModels
{
    public class ItemsViewModelSpec : ViewModelSpecHelper
    {
        protected static IItemService itemService;
        protected static IMvxMessenger messenger;
        protected static ItemsViewModel testee;

        private Establish context = () =>
        {
            itemService = A.Fake<IItemService>();
            messenger = A.Fake<IMvxMessenger>();
            testee = new ItemsViewModel(itemService, messenger);
        };
    }

    [Subject(typeof(ItemsViewModel))]
    public class when_adding_an_item : ItemsViewModelSpec
    {
        private Because of = () =>
        {
            testee.AddItemCommand.Execute(null);
        };

        private It should_have_one_navigation_request = () =>
        {
            mockDispatcher.NavigateRequests.Count.Should().Be(1);
        };

        private It should_navigate_to_add_item_view = () =>
        {
            mockDispatcher.NavigateRequests[0].ViewModelType.Should().Be(typeof (AddItemViewModel));
        };
    }

    [Subject(typeof(ItemsViewModel))]
    public class when_selecting_an_item : ItemsViewModelSpec
    {
        private static Item item;

        private Establish context = () =>
        {
            item = new Item {Id = 22};
        };

        private Because of = () =>
        {
            testee.ShowDetailCommand.Execute(item);
        };

        private It should_have_one_navigation_request = () =>
        {
            mockDispatcher.NavigateRequests.Count.Should().Be(1);
        };

        private It should_have_item_id_as_navigation_parameter = () =>
        {
            mockDispatcher.NavigateRequests[0].ParameterValues["id"].Should().Be(item.Id.ToString(CultureInfo.InvariantCulture));;
        };

        private It should_navigate_to_detail_item_view = () =>
        {
            mockDispatcher.NavigateRequests[0].ViewModelType.Should().Be(typeof(DetailItemViewModel));
        };
    }
}