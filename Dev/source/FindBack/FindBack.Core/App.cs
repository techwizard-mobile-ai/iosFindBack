namespace FindBack.Core
{
    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.ViewModels;

    using FindBack.Core.Services;
    using FindBack.Core.ViewModels;

    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterType<IItemProvider, ItemProvider>();
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<ItemsViewModel>());
        }
    }
}