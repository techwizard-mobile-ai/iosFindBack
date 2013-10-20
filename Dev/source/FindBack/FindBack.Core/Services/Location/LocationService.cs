namespace FindBack.Core.Services.Location
{
    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.Plugins.Location;
    using Cirrious.MvvmCross.Plugins.Messenger;

    public class LocationService : ILocationService
    {
        private readonly IMvxGeoLocationWatcher _locationWatcher;

        private readonly IMvxMessenger _messenger;

        public LocationService(IMvxGeoLocationWatcher locationWatcher, IMvxMessenger messenger)
        {
            this._locationWatcher = locationWatcher;
            this._messenger = messenger;
            this._locationWatcher.Start(new MvxGeoLocationOptions(), this.OnLocation, this.OnLocationError);
        }

        private void OnLocationError(MvxLocationError error)
        {
            Mvx.Error("Error in retrieving location {0}", error.Code);
        }

        private void OnLocation(MvxGeoLocation location)
        {
            var message = new LocationMessage(
                this, 
                location.Coordinates.Latitude,
                location.Coordinates.Longitude);
            this._messenger.Publish(message);
        }
    }
}