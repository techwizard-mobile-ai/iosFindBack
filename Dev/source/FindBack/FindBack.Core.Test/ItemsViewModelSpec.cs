using System.Globalization;
using FindBack.Core.Services.DataStore;
using FindBack.Core.ViewModels;
using FluentAssertions;
using Machine.Specifications;

namespace FindBack.Core.Test
{
    [Subject(typeof(ItemsViewModel))]
    public class when_adding_an_item : ViewModelSpecHelper
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
    public class when_selecting_an_item : ViewModelSpecHelper
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