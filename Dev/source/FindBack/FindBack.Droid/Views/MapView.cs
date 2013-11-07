using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging;
using FindBack.Core.ViewModels;

namespace FindBack.Droid.Views
{
    [Activity(Label = "Where is it?")]
    public class MapView : MvxFragmentActivity
    {
        private Marker _marker;
        private CenterHelper _centerHelper;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MapView);

            var viewModel = (MapViewModel)ViewModel;

            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);

            var options = new MarkerOptions();
            var latLng = new LatLng(viewModel.Latitude, viewModel.Longitude);
            options.SetPosition(latLng);
            //options.SetTitle("Keith");
            _marker = mapFragment.Map.AddMarker(options);
            _marker.Position = latLng;

            _centerHelper = new CenterHelper(mapFragment.Map);
            _centerHelper.Center = latLng;
        }

        public class CenterHelper
        {
            private GoogleMap _map;

            public CenterHelper(GoogleMap map)
            {
                _map = map;
            }

            public LatLng Center
            {
                get { return _map.Projection.VisibleRegion.LatLngBounds.Center; }
                set
                {
                    var center = CameraUpdateFactory.NewLatLngZoom(value, 12f);
                    _map.MoveCamera(center);
                    _map.MyLocationEnabled = true;
                    _map.MapType = GoogleMap.MapTypeHybrid;
                }
            }
        }
    }
}