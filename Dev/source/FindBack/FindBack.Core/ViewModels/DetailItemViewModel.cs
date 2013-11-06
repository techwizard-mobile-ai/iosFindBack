namespace FindBack.Core.ViewModels
{
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

        public IMvxCommand DeleteCommand
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

        //public IMvxCommand MapCommand { get { return new MvxCommand(() => ShowViewModel<MapViewModel>()); } }
        public IMvxCommand MapCommand { get
        {
            var lat = Item.Latitude;
            return new MvxCommand(() => ShowViewModel<MapViewModel>(new
        {
            latitude = Item.Latitude, 
            longitude = Item.Longitude
        })); } }
    }
}