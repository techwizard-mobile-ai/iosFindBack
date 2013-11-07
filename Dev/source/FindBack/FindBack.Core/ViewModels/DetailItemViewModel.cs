using Cirrious.MvvmCross.Plugins.Messenger;
using FindBack.Core.Services.Location;

namespace FindBack.Core.ViewModels
{
    using Cirrious.MvvmCross.ViewModels;

    using Services.DataStore;
    using Services.Items;

    public class DetailItemViewModel : MvxViewModel
    {
        private readonly IItemService _itemService;
        private readonly IMvxMessenger _messenger;
        private Item _item;

        public DetailItemViewModel(IItemService itemService, IMvxMessenger messenger)
        {
            _itemService = itemService;
            _messenger = messenger;
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

        public IMvxCommand MapCommand { 
            get
                {
                    return new MvxCommand(() => ShowViewModel<MapViewModel>(new { latitude = Item.Latitude, longitude = Item.Longitude }));
                } 
        }
    }
}