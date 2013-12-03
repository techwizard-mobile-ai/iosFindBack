namespace FindBack.Touch.Views
{
    using System.Drawing;

    using MonoTouch.Foundation;
    using Cirrious.MvvmCross.Touch.Views;

    using FindBack.Core.ViewModels;

    using MonoTouch.CoreLocation;
    using MonoTouch.MapKit;
    using MonoTouch.UIKit;

    [Register("MapView")]
    public class MapView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            var mapView = new MKMapView();
            mapView.Delegate = new MyDelegate();
            View = mapView;

            base.ViewDidLoad();

            var mapViewModel = (MapViewModel)ViewModel;

            var keithAnnotation = new ItemAnnotation(mapViewModel);

            mapView.AddAnnotation(keithAnnotation);

            mapView.SetRegion(MKCoordinateRegion.FromDistance(
            new CLLocationCoordinate2D(mapViewModel.Latitude, mapViewModel.Longitude),
                200,
                200), true);
        }



        public class ItemAnnotation : MKAnnotation
        {
            public ItemAnnotation(MapViewModel mapViewModel)
            {
                Coordinate = new CLLocationCoordinate2D(mapViewModel.Latitude, mapViewModel.Longitude);
            }

            public override sealed CLLocationCoordinate2D Coordinate { get; set; }
        }

        public class MyDelegate : MKMapViewDelegate
        {
            public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, NSObject annotation)
            {
                var pin = mapView.DequeueReusableAnnotation("pin");
                if (pin == null)
                {
                    pin = new MKAnnotationView(annotation, "pin")
                          {
                              Image = UIImage.FromFile("ic_action_place.png"),
                              CenterOffset = new PointF(0, -30)
                          };
                }
                else
                {
                    pin.Annotation = annotation;
                }

                return pin;
            }
        }
    }
}
