using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;
using FindBack.Core.Services.DataStore;

namespace FindBack.Core.Converters
{
    public class ItemLocationConverter
        : MvxValueConverter<Item, string>
    {
        protected override string Convert(Item value, Type targetType, object parameter, CultureInfo culture)
        {
            var latitude = GeoCoordinate.FromDouble(value.Latitude);
            var longitude = GeoCoordinate.FromDouble(value.Longitude);

            if (latitude == null || longitude == null)
            {
                return "unknown";
            }

            return latitude.ToLatitude() + "   " + longitude.ToLongitude();
        }
    }
}