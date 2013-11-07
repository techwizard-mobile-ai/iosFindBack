using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;

namespace FindBack.Core.ViewModels
{
    public class MapViewModel: MvxViewModel
    {
        private readonly MvxSubscriptionToken _token;

        private double _latitude;
        private double _longitude;

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