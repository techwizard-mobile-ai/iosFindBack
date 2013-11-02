using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.Test.Core;
using Cirrious.MvvmCross.Views;
using FakeItEasy;
using FindBack.Core.Services.Items;
using FindBack.Core.ViewModels;
using Machine.Specifications;

namespace FindBack.Core.Test
{
    public class ViewModelSpecHelper : MvxIoCSupportingTest
    {
        protected static MockDispatcher mockDispatcher;
        protected static IItemService itemService;
        protected static IMvxMessenger messenger;
        protected static ItemsViewModel testee;

        public ViewModelSpecHelper()
        {
            base.ClearAll();
            mockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxStringToTypeParser>(new MvxStringToTypeParser());
        }

        private Establish context = () =>
        {
            itemService = A.Fake<IItemService>();
            messenger = A.Fake<IMvxMessenger>();
            testee = new ItemsViewModel(itemService, messenger);
        };
    }
}