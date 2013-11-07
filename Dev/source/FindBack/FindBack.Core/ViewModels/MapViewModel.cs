using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FindBack.Core.Services.Location;

namespace FindBack.Core.ViewModels
{
    public class MapViewModel: MvxViewModel
    {
        private readonly MvxSubscriptionToken _token;

        private Location _location;
        private double _latitude;
        private double _longitude;

        public Location Location 
        {   
            get { return _location; }
            set { _location = value; RaisePropertyChanged(() => Location); }
        }

        public double Latitude 
        {   
            get { return _latitude; }
            set { _latitude = value; RaisePropertyChanged(() => Latitude); }
        }

        public double Longitude 
        {   
            get { return _longitude; }
            set { _longitude = value; RaisePropertyChanged(() => Longitude); }
        }

        public void Init(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}