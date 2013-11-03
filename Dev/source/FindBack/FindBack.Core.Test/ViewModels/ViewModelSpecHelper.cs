using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.Test.Core;
using Cirrious.MvvmCross.Views;

namespace FindBack.Core.Test.ViewModels
{
    public class ViewModelSpecHelper : MvxIoCSupportingTest
    {
        protected static MockDispatcher mockDispatcher;

        public ViewModelSpecHelper()
        {
            base.ClearAll();
            mockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxStringToTypeParser>(new MvxStringToTypeParser());
        }
    }
}