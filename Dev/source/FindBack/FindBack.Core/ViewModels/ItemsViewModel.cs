namespace FindBack.Core.ViewModels
{
    using System.Collections.Generic;
    using System.Windows.Input;

    using Cirrious.MvvmCross.Plugins.Messenger;
    using Cirrious.MvvmCross.ViewModels;

    using Services.DataStore;
    using Services.Items;

    public class ItemsViewModel : MvxViewModel
    {
        private readonly IItemService _itemService;
        // ReSharper disable once NotAccessedField.Local
        private readonly MvxSubscriptionToken _collectionChangedToken;

        private List<Item> _items;

        private int _totalCount;

        private MvxCommand _addItemCommand;

        public ItemsViewModel(IItemService itemService, IMvxMessenger messenger)
        {
            _itemService = itemService;
            ReloadList();
            _collectionChangedToken = messenger.Subscribe<CollectionChangedMessage>(OnCollectionChanged);
        }

        public List<Item> Items
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

        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; RaisePropertyChanged(() => TotalCount); }
        }

        public ICommand AddItemCommand
        {
            get
            {
                _addItemCommand = _addItemCommand ?? new MvxCommand(GoToAddItem);
                return _addItemCommand;
            }
        }

        public ICommand ShowDetailCommand
        {
            get
            {
                return new MvxCommand<Item>(item => ShowViewModel<DetailItemViewModel>(new { id = item.Id }));
            }
        }

        private void ReloadList()
        {
            Items = _itemService.GetItems();
            RefreshDataCount();
        }

        private void OnCollectionChanged(CollectionChangedMessage obj)
        {
            ReloadList();
        }

        private void GoToAddItem()
        {
            ShowViewModel<AddItemViewModel>();
        }

        private void RefreshDataCount()
        {
            TotalCount = _itemService.Count;
        }
    }
}