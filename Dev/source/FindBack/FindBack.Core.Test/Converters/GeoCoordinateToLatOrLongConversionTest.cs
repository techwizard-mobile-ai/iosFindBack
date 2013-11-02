using FindBack.Core.Converters;
using FindBack.Core.Services.DataStore;
using FluentAssertions;
using NUnit.Framework;

namespace FindBack.Core.Test.Converters
{
    [TestFixture]
    public class GeoCoordinateToLatOrLongConversionTest
    {
        [TestCase(false, 47, 3, 49, 543, "47° 03' 49\".543 N")]
        [TestCase(true, 47, 3, 49, 543, "47° 03' 49\".543 S")]
        [TestCase(false, 0, 0, 0, 0, "0° 00' 00\".000 N")]
        public void ConvertGeoCoordinateToLatitude_ShouldConvertToLatitude(bool isNegative, int degrees, int minutes, int seconds, int millisecs, string expectedLatitude)
        {
            GeoCoordinate coordinate = new GeoCoordinate
            {
                IsNegative = isNegative,
                Degrees = degrees,
                Minutes = minutes,
                Seconds = seconds,
                Milliseconds = millisecs
            };

            coordinate.ToLatitude().Should().Be(expectedLatitude);
        }

        [TestCase(false, 47, 3, 49, 543, "47° 03' 49\".543 E")]
        [TestCase(true, 47, 3, 49, 543, "47° 03' 49\".543 W")]
        [TestCase(false, 0, 0, 0, 0, "0° 00' 00\".000 E")]
        public void ConvertGeoCoordinateToLongitude_ShouldConvertToLongitude(bool isNegative, int degrees, int minutes, int seconds, int millisecs, string expectedLatitude)
        {
            GeoCoordinate coordinate = new GeoCoordinate
            {
                IsNegative = isNegative,
                Degrees = degrees,
                Minutes = minutes,
                Seconds = seconds,
                Milliseconds = millisecs
            };

            coordinate.ToLongitude().Should().Be(expectedLatitude);

        }
    }
}