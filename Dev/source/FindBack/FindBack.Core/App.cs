namespace FindBack.Core
{
    using Cirrious.CrossCore;
    using Cirrious.CrossCore.IoC;
    using Cirrious.MvvmCross.ViewModels;

    using FindBack.Core.Services;
    using FindBack.Core.ViewModels;

    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<IItemProvider, ItemProvider>();
            RegisterAppStart<ItemsViewModel>();
        }
    }
}