using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;

namespace FindBack.Core.Converters
{
    public class LatitudeCoordinateConverter
        : MvxValueConverter<double, string>
    {
        protected override string Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            var coordinate = GeoCoordinate.FromDouble(value);

            if (coordinate == null)
            {
                return "Latitude unknown";
            }

            return coordinate.ToLatitude();
        }
    }
}