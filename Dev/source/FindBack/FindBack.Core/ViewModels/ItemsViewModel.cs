namespace FindBack.Core.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using Cirrious.MvvmCross.ViewModels;

    using FindBack.Core.Model;
    using FindBack.Core.Services;

    public class ItemsViewModel : MvxViewModel
    {
        private readonly IItemProvider _itemProvider;

        private ObservableCollection<Item> _items;

        private MvxCommand _addItemCommand;

        public ItemsViewModel(IItemProvider itemProvider)
        {
            this._itemProvider = itemProvider;
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
            Items = this._itemProvider.GetItems();
            base.Start();
        }
    }
}