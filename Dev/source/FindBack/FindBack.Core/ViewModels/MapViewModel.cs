using Cirrious.MvvmCross.ViewModels;

namespace FindBack.Core.ViewModels
{
    public class MapViewModel: MvxViewModel
    {
        private Location _location;
        public Location Location 
        {   
            get { return _location; }
            set { _location = value; RaisePropertyChanged(() => Location); }
        }

        private double _lat;
        public double Lat 
        {   
            get { return _lat; }
            set { _lat = value; RaisePropertyChanged(() => Lat); }
        }

        private double _lng;
        public double Lng 
        {   
            get { return _lng; }
            set { _lng = value; RaisePropertyChanged(() => Lng); }
        }

        public MapViewModel()
        {
            Location = new Location()
                {
                    Lat = 47.063762,
                    Lng = 8.311063
                };
        }


        public void Init(double latitude, double longitude)
        {
            //Location = new Location()
            //{
            //    Lat = latitude,
            //    Lng = longitude
            //};
        }
    }
}