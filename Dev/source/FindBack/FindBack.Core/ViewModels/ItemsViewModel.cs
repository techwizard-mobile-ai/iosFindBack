namespace FindBack.Core.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Cirrious.MvvmCross.ViewModels;

    using FindBack.Core.Model;
    using FindBack.Core.Services;

    public class ItemsViewModel : MvxViewModel
    {
        private readonly IItemProvider itemProvider;

        private ObservableCollection<Item> _items;
		private string _welcomeText;

		public string WelcomeText 
		{
			get 
			{
				return _welcomeText;
			}
			set 
			{
				_welcomeText = value;
				RaisePropertyChanged (() => WelcomeText);
			}
		}
        public ObservableCollection<Item> Items
        {
            get
            {
                return _items;
            }
            private set
            {
                _items = value;
				RaisePropertyChanged (() => Items);
            }
        }

        public ItemsViewModel(IItemProvider itemProvider)
        {
            this.itemProvider = itemProvider;
        }

        public override void Start()
        {
            Items = itemProvider.GetItems();
			WelcomeText = "Welcome to FindBack";
            base.Start();
        }
    }
}