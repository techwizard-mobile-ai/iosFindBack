namespace FindBack.Core.ViewModels
{
    using System;
    using System.IO;

    using Cirrious.MvvmCross.Plugins.File;
    using Cirrious.MvvmCross.Plugins.Messenger;
    using Cirrious.MvvmCross.Plugins.PictureChooser;
    using Cirrious.MvvmCross.ViewModels;

    using FindBack.Core.Services.DataStore;
    using FindBack.Core.Services.Items;
    using FindBack.Core.Services.Location;

    public class AddItemViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private readonly IMvxPictureChooserTask _pictureChooserTask;

        private readonly IItemService _itemService;
        private readonly IMvxFileStore _fileStore;
        private readonly IMvxMessenger _messenger;
        private readonly MvxSubscriptionToken _token;

        private double? _longitude;
        private double? _latitude;
        private bool _locationKnown;
        private string _itemName;
        private string _description;
        private byte[] _pictureBytes;

        private MvxCommand _choosePictureCommand;
        private MvxCommand _takePictureCommand;
        private MvxCommand _saveCommand;

        public AddItemViewModel(ILocationService locationService, IMvxMessenger messenger, IMvxPictureChooserTask pictureChooserTask, IItemService itemService, IMvxFileStore fileStore)
        {
            _locationService = locationService;
            _pictureChooserTask = pictureChooserTask;
            _itemService = itemService;
            this._fileStore = fileStore;
            _token = messenger.SubscribeOnMainThread<LocationMessage>(OnLocationMessage);
            GetInitialLocation();
        }

        public byte[] PictureBytes
        {
            get { return this._pictureBytes; }
            set { this._pictureBytes = value; RaisePropertyChanged(() => this.PictureBytes); }
        }

        public double? Longitude
        {
            get { return this._longitude; }
            set { this._longitude = value; RaisePropertyChanged(() => Longitude); }
        }

        public double? Latitude
        {
            get { return this._latitude; }
            set { this._latitude = value; RaisePropertyChanged(() => Latitude); }
        }

        public bool LocationKnown
        {
            get { return _locationKnown; }
            set { _locationKnown = value; RaisePropertyChanged(() => LocationKnown); }
        }

        public string ItemName
        {
            get { return this._itemName; }
            set { this._itemName = value; RaisePropertyChanged(() => ItemName); }
        }

        public string Description
        {
            get { return this._description; }
            set { this._description = value; RaisePropertyChanged(() => Description); }
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
            double? lat = null;
            double? lng = null;
            if (_locationService.TryGetLatestLocation(out lat, out lng))
            {
                LocationKnown = true;
                Latitude = lat;
                Longitude = lng;
            }
        }

        private void DoSave()
        {
            if (!this.ValidateItem())
            {
                return;
            }

            var collectedItem = new Item {
                                        ItemName = this.ItemName,
                                        Latitude = this.Latitude,
                                        Longitude = this.Longitude,
                                        ItemCreated = DateTime.UtcNow,
                                        Description = this.Description,
                                        ImagePath = this.GenerateImagePath()
                                    };

            this._itemService.Add(collectedItem);
            this.Close(this);
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
            this._pictureChooserTask.TakePicture(400, 95, this.OnPicture, () => { });
        }

        private void DoChoosePicture()
        {
            _pictureChooserTask.ChoosePictureFromLibrary(400, 95, OnPicture, () => { });
        }

        private void OnPicture(Stream pictureStream)
        {
            var memoryStream = new MemoryStream();
            pictureStream.CopyTo(memoryStream);
            this.PictureBytes = memoryStream.ToArray();
        }

        private void OnLocationMessage(LocationMessage locationMessage)
        {
            Latitude = locationMessage.Latitude;
            Longitude = locationMessage.Longitude;
        }


        private string GenerateImagePath()
        {
            if (this.PictureBytes == null)
                return null;

            var randomFileName = "Image" + Guid.NewGuid().ToString("N") + ".jpg";
            _fileStore.EnsureFolderExists("Images");
            var path = _fileStore.PathCombine("Images", randomFileName);
            _fileStore.WriteFile(path, this.PictureBytes);
            return path;
        }
    }
}