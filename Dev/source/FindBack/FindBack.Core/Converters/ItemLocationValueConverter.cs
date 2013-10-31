using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;
using FindBack.Core.Services.DataStore;

namespace FindBack.Core.Converters
{
    public class ItemLocationValueConverter
        : MvxValueConverter<Item>
    {
        protected override object Convert(Item value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Latitude == 0 && value.Longitude == 0)
                return "unknown";

            return string.Format("{0:0.0000}, {1:0.0000}", value.Latitude, value.Longitude);
        }
    }
}