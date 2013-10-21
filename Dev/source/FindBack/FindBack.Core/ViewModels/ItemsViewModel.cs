namespace FindBack.Core.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using Cirrious.MvvmCross.ViewModels;

    using FindBack.Core.Model;
    using FindBack.Core.Services;
    using FindBack.Core.Services.Items;

    public class ItemsViewModel : MvxViewModel
    {
        private readonly IItemService itemService;

        private ObservableCollection<Item> _items;

        private MvxCommand _addItemCommand;

        public ItemsViewModel(IItemService itemService)
        {
            this.itemService = itemService;
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
                RaisePropertyChanged(() => Items);
            }
        }

        public ICommand AddItemCommand
        {
            get
            {
                _addItemCommand = _addItemCommand ?? new MvxCommand(this.GoToAddItem);
                return _addItemCommand;
            }
        }

        private void GoToAddItem()
        {
            ShowViewModel<AddItemViewModel>();
        }

        public override void Start()
        {
            Items = this.itemService.GetItems();
            base.Start();
        }
    }
}