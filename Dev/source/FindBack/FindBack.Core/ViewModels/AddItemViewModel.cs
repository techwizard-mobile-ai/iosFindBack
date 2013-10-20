namespace FindBack.Core.ViewModels
{
    using System.IO;

    using Cirrious.MvvmCross.Plugins.Messenger;
    using Cirrious.MvvmCross.Plugins.PictureChooser;
    using Cirrious.MvvmCross.ViewModels;

    using FindBack.Core.Services.Location;

    public class AddItemViewModel : MvxViewModel
    {
        private ILocationService _locationService;
        private readonly IMvxPictureChooserTask _pictureChooserTask;
        private readonly IMvxMessenger _messenger;
        private readonly MvxSubscriptionToken _token;

        private double _longitude;
        private double _latitude;

        private byte[] _bytes;

        private MvxCommand _choosePictureCommand;

        private MvxCommand _takePictureCommand;

        public AddItemViewModel(ILocationService locationService, IMvxMessenger messenger, IMvxPictureChooserTask pictureChooserTask)
        {
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
            _pictureChooserTask = pictureChooserTask;
        }

        public byte[] Bytes
        {
            get { return this._bytes; }
            set { this._bytes = value; RaisePropertyChanged(() => Bytes); }
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
            Bytes = memoryStream.ToArray();
        }

        private void OnLocationMessage(LocationMessage locationMessage)
        {
            Latitude = locationMessage.Latitude;
            Longitude = locationMessage.Longitude;
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
    }
}