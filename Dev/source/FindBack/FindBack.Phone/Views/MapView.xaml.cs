using System;
using System.Device.Location;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Cirrious.MvvmCross.WindowsPhone.Views;
using FindBack.Core.ViewModels;
using Microsoft.Phone.Maps;
using Microsoft.Phone.Maps.Controls;

namespace FindBack.Phone.Views
{
    public partial class MapView : MvxPhonePage
    {
        const int MIN_ZOOM_LEVEL = 1;
        const int MAX_ZOOM_LEVEL = 20;

        MapCartographicMode _mapMode = MapCartographicMode.Hybrid;

        public MapView()
        {
            InitializeComponent();
        }

        // Placeholder code to contain the ApplicationID and AuthenticationToken
        // that must be obtained online from the Windows Phone Dev Center
        // before publishing an app that uses the Map control.
        private void sampleMap_Loaded(object sender, RoutedEventArgs e)
        {
            MapsSettings.ApplicationContext.ApplicationId = "<applicationid>";
            MapsSettings.ApplicationContext.AuthenticationToken = "<authenticationtoken>";
            map.ZoomLevel = MAX_ZOOM_LEVEL - 3;
            map.CartographicMode = _mapMode;
            var vm = (MapViewModel)ViewModel;
            var location = new GeoCoordinate(vm.Latitude, vm.Longitude);
            ShowLocation(location);
        }

        private void AppBarToggleMapTypeButton_OnClick(object sender, EventArgs e)
        {
            switch (_mapMode)
            {
                case MapCartographicMode.Hybrid:
                    _mapMode = MapCartographicMode.Road;
                    break;
                case MapCartographicMode.Road:
                    _mapMode = MapCartographicMode.Aerial;
                    break;
                case MapCartographicMode.Aerial:
                    _mapMode = MapCartographicMode.Terrain;
                    break;
                case MapCartographicMode.Terrain:
                    _mapMode = MapCartographicMode.Hybrid;
                    break;
            }

            map.CartographicMode = _mapMode;
        }

        private void AppBarZoomInButton_OnClick(object sender, EventArgs e)
        {
            if (map.ZoomLevel < MAX_ZOOM_LEVEL)
            {
                map.ZoomLevel++;
            }
        }

        private void AppBarZoomOutButton_OnClick(object sender, EventArgs e)
        {
            if (map.ZoomLevel > MIN_ZOOM_LEVEL)
            {
                map.ZoomLevel--;
            }
        }

        private void ShowLocation(GeoCoordinate coordinate)
        {           
            var locationLayer = CreateLocationLayer(coordinate);
            map.Center = coordinate;
            map.Layers.Add(locationLayer);
        }

        private MapLayer CreateLocationLayer(GeoCoordinate coordinate)
        {
            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = CreateCircle();
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = coordinate;
            var layer = new MapLayer();
            layer.Add(myLocationOverlay);
            return layer;
        }

        private static Ellipse CreateCircle()
        {
            Ellipse myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(Colors.Blue);
            myCircle.Height = 20;
            myCircle.Width = 20;
            myCircle.Opacity = 50;
            return myCircle;
        }
    }
}