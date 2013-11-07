namespace FindBack.Core.ViewModels
{
    using System;
    using System.IO;
    using Cirrious.MvvmCross.Plugins.Messenger;
    using Cirrious.MvvmCross.Plugins.PictureChooser;
    using Cirrious.MvvmCross.ViewModels;

    using Services.DataStore;
    using Services.Items;
    using Services.Location;

    public class AddItemViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private readonly IMvxPictureChooserTask _pictureChooserTask;

        private readonly IItemService _itemService;
        private readonly IImageStorageService _imageStore;
        // ReSharper disable once NotAccessedField.Local
        private readonly MvxSubscriptionToken _token;

        private double _longitude;
        private double _latitude;
        private bool _locationKnown;
        private string _itemName;
        private string _description;
        private byte[] _pictureBytes;

        private MvxCommand _choosePictureCommand;
        private MvxCommand _takePictureCommand;
        private MvxCommand _saveCommand;

        public AddItemViewModel(ILocationService locationService, IMvxMessenger messenger, IMvxPictureChooserTask pictureChooserTask, IItemService itemService, IImageStorageService imageStore)
        {
            _locationService = locationService;
            _pictureChooserTask = pictureChooserTask;
            _itemService = itemService;
            _imageStore = imageStore;
            _token = messenger.SubscribeOnMainThread<LocationMessage>(OnLocationMessage);
            GetInitialLocation();
        }

        public byte[] PictureBytes
        {
            get { return _pictureBytes; }
            set { _pictureBytes = value; RaisePropertyChanged(() => PictureBytes); }
        }

        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; RaisePropertyChanged(() => Longitude); }
        }

        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; RaisePropertyChanged(() => Latitude); }
        }

        public bool LocationKnown
        {
            get { return _locationKnown; }
            set { _locationKnown = value; RaisePropertyChanged(() => LocationKnown); }
        }

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; RaisePropertyChanged(() => ItemName); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged(() => Description); }
        }

        public System.Windows.Input.ICommand SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new MvxCommand(DoSave);
                return _saveCommand;
            }
        }

        public System.Windows.Input.ICommand TakePictureCommand
        {
            get
            {
                _takePictureCommand = _takePictureCommand ?? new MvxCommand(DoTakePicture);
                return _takePictureCommand;
            }
        }

        public System.Windows.Input.ICommand ChoosePictureCommand
        {
            get
            {
                _choosePictureCommand = _choosePictureCommand ?? new MvxCommand(DoChoosePicture);
                return _choosePictureCommand;
            }
        }

        private void GetInitialLocation()
        {
            double latitude;
            double longitude;
            if (_locationService.TryGetLatestLocation(out latitude, out longitude))
            {
                LocationKnown = true;
                Latitude = latitude;
                Longitude = longitude;
            }
        }

        private void DoSave()
        {
            if (!ValidateItem())
            {
                return;
            }

            var collectedItem = new Item {
                                        ItemName = ItemName,
                                        Latitude = Latitude,
                                        Longitude = Longitude,
                                        ItemCreated = DateTime.UtcNow,
                                        Description = Description,
                                        ImagePath = _imageStore.SaveImageToFile(PictureBytes)
                                    };

            _itemService.Add(collectedItem);
            Close(this);
        }

        private bool ValidateItem()
        {
            if (string.IsNullOrEmpty(ItemName))
            {
                return false;
            }

            return true;
        }

        private void DoTakePicture()
        {
            _pictureChooserTask.TakePicture(400, 95, OnPicture, () => { });
        }

        private void DoChoosePicture()
        {
            _pictureChooserTask.ChoosePictureFromLibrary(400, 95, OnPicture, () => { });
        }

        private void OnPicture(Stream pictureStream)
        {
            var memoryStream = new MemoryStream();
            pictureStream.CopyTo(memoryStream);
            PictureBytes = memoryStream.ToArray();
        }

        private void OnLocationMessage(LocationMessage locationMessage)
        {
            Latitude = locationMessage.Latitude;
            Longitude = locationMessage.Longitude;
        }
    }
}