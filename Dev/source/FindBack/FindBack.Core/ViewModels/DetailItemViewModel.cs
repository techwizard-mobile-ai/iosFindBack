namespace FindBack.Core.ViewModels
{
    using System.Windows.Input;

    using Cirrious.MvvmCross.ViewModels;

    using Services.DataStore;
    using Services.Items;

    public class DetailItemViewModel : MvxViewModel
    {
        private readonly IItemService _itemService;
        private Item _item;

        public DetailItemViewModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void Init(int id)
        {
            Item = _itemService.GetItem(id);
        }

        public Item Item
        {
            get { return _item; }
            set { _item = value; RaisePropertyChanged(() => Item); }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _itemService.Delete(Item);
                    Close(this);
                });
            }
        }
    }
}