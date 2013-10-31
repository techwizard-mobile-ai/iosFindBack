using FindBack.Core.Converters;
using FindBack.Core.Services.DataStore;
using FluentAssertions;
using NUnit.Framework;

namespace FindBack.Core.Test.Converters
{
    [TestFixture]
    public class CoordinateConversionTest
    {
        [TestCase(47.063762, false, 47, 3, 49, 543)]
        public void WhenGivenDecimalPosition_ShouldConvertToDegMinSecPosition(double? coordinate, bool isNegative, int degrees, int minutes, int seconds, int millisecs)
        {
            GeoCoordinate result = coordinate.ToCoordinate();

            result.IsNegative.Should().Be(isNegative);
            result.Degrees.Should().Be(degrees);
            result.Minutes.Should().Be(minutes);
            result.Seconds.Should().Be(seconds);
            result.Milliseconds.Should().Be(millisecs);
        }
    }
}