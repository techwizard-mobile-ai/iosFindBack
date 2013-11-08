namespace FindBack.Core.Services.Location
{
    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.Plugins.Location;
    using Cirrious.MvvmCross.Plugins.Messenger;

    public class LocationService : ILocationService
    {
        private readonly IMvxMessenger _messenger;
        private readonly object _lockObject = new object();
        private MvxGeoLocation _latestLocation;

        public LocationService(IMvxLocationWatcher locationWatcher, IMvxMessenger messenger)
        {
            _messenger = messenger;
            locationWatcher.Start(new MvxLocationOptions(), OnLocation, OnLocationError);
        }

        private void OnLocationError(MvxLocationError error)
        {
            Mvx.Error("Error in retrieving location {0}", error.Code);
        }

        private void OnLocation(MvxGeoLocation location)
        {
            lock (_lockObject)
            {
                _latestLocation = location;
            }

            var message = new LocationMessage(this,
                                location.Coordinates.Latitude,
                                location.Coordinates.Longitude);

            _messenger.Publish(message);
        }

        public bool TryGetLatestLocation(out double lat, out double lng)
        {
            lock (_lockObject)
            {
                if (_latestLocation == null)
                {
                    lat = double.PositiveInfinity;
                    lng = double.PositiveInfinity;
                    return false;
                }

                lat = _latestLocation.Coordinates.Latitude;
                lng = _latestLocation.Coordinates.Longitude;
                return true;
            }
        }
    }
}