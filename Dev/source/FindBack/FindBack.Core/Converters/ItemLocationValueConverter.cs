using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;
using FindBack.Core.Services.DataStore;

namespace FindBack.Core.Converters
{
    public class ItemLocationValueConverter
        : MvxValueConverter<Item, string>
    {
        protected override string Convert(Item value, Type targetType, object parameter, CultureInfo culture)
        {
            var latitude = value.Latitude.ToCoordinate();
            var longitude = value.Longitude.ToCoordinate();

            if (latitude == null || longitude == null)
            {
                return "unknown";
            }

            return latitude.ToLatitude() + "   " + longitude.ToLongitude();
        }
    }
}