namespace FindBack.Core.ViewModels
{
    using System.Collections.ObjectModel;

    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.Plugins.Location;
    using Cirrious.MvvmCross.ViewModels;

    using FindBack.Core.Model;
    using FindBack.Core.Services;

    public class AddItemViewModel : MvxViewModel
    {
        private IMvxGeoLocationWatcher _locationWatcher;
        private double _longitude;
        private double _latitude;

        public AddItemViewModel(IMvxGeoLocationWatcher locationWatcher)
        {
            _locationWatcher = locationWatcher;
            _locationWatcher.Start(new MvxGeoLocationOptions(), OnLocation, OnLocationError);
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

        private void OnLocationError(MvxLocationError error)
        {
            Mvx.Error("Error in retrieving location {0}", error.Code);
        }

        private void OnLocation(MvxGeoLocation location)
        {
            Latitude = location.Coordinates.Latitude;
            Longitude = location.Coordinates.Longitude;
        }
    }
}