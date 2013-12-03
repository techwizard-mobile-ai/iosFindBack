using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;

using Cirrious.MvvmCross.Droid.Fragging;
using FindBack.Core.ViewModels;

namespace FindBack.Droid.Views
{
    [Activity(Label = "Where is it?")]
    public class MapView : MvxFragmentActivity
    {
        private Marker marker;
        private CenterHelper centerHelper;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MapView);

            var viewModel = (MapViewModel)ViewModel;

            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);

            var options = new MarkerOptions();
            var latLng = new LatLng(viewModel.Latitude, viewModel.Longitude);
            options.SetPosition(latLng);
            this.marker = mapFragment.Map.AddMarker(options);
            this.marker.Position = latLng;

            this.centerHelper = new CenterHelper(mapFragment.Map);
            this.centerHelper.Center = latLng;
        }

        public class CenterHelper
        {
            private readonly GoogleMap map;

            public CenterHelper(GoogleMap map)
            {
                this.map = map;
            }

            public LatLng Center
            {
                get { return this.map.Projection.VisibleRegion.LatLngBounds.Center; }
                set
                {
                    var center = CameraUpdateFactory.NewLatLngZoom(value, 18f);
                    this.map.MoveCamera(center);
                    this.map.MyLocationEnabled = true;
                    this.map.MapType = GoogleMap.MapTypeHybrid;
                }
            }
        }
    }
}