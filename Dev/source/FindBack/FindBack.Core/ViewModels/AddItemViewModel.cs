namespace FindBack.Core.ViewModels
{
    using System.Collections.ObjectModel;

    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.Plugins.Location;
    using Cirrious.MvvmCross.Plugins.Messenger;
    using Cirrious.MvvmCross.ViewModels;

    using FindBack.Core.Model;
    using FindBack.Core.Services;
    using FindBack.Core.Services.Location;

    public class AddItemViewModel : MvxViewModel
    {
        private ILocationService _locationService;

        private readonly IMvxMessenger _messenger;

        private readonly MvxSubscriptionToken _token;

        private double _longitude;
        private double _latitude;

        public AddItemViewModel(ILocationService locationService, IMvxMessenger messenger)
        {
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
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