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
        [TestCase(-123.455435, true, 123, 27, 19, 565)]
        [TestCase(-180.00, true, 180, 0, 0, 0)]
        [TestCase(180.00, false, 180, 0, 0, 0)]
        [TestCase(0.00, false, 0, 0, 0, 0)]
        [TestCase(-0.0001, true, 0, 0, 0, 360)]
        public void WhenGivenDecimalPosition_ShouldConvertToDegMinSecPosition(double? coordinate, bool isNegative, int degrees, int minutes, int seconds, int millisecs)
        {
            GeoCoordinate result = coordinate.ToCoordinate();

            result.IsNegative.Should().Be(isNegative);
            result.Degrees.Should().Be(degrees);
            result.Minutes.Should().Be(minutes);
            result.Seconds.Should().Be(seconds);
            result.Milliseconds.Should().Be(millisecs);
        }

        [TestCase(-180.01)]
        [TestCase(180.01)]
        [TestCase(null)]
        public void WhenGivenOutOfRangeDecimalPosition_ShouldReturnNull(double? coordinate)
        {
            GeoCoordinate result = coordinate.ToCoordinate();

            result.Should().BeNull();
        }
    }
}