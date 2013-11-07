using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;

namespace FindBack.Core.Converters
{
    public class LongitudeCoordinateConverter
        : MvxValueConverter<double, string>
    {
        protected override string Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            var coordinate = GeoCoordinate.FromDouble(value);

            if (coordinate == null)
            {
                return "Longitude unknown";
            }

            return coordinate.ToLongitude();
        }
    }
}