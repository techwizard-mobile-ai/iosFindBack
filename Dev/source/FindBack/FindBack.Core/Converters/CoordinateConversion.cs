namespace FindBack.Core.Converters
{
    public static class CoordinateConversion
    {
        public static GeoCoordinate ToCoordinate(this double? coordinate)
        {
            return GeoCoordinate.FromDouble(coordinate);
        }

        public static string ToLatitude(this GeoCoordinate coordinate)
        {
            return string.Format(
                "{0} {1}",
                coordinate.ToDegMinSec(),
                coordinate.IsNegative ? 'S' : 'N');
        }

        public static string ToLongitude(this GeoCoordinate coordinate)
        {
            return string.Format(
                "{0} {1}",
                coordinate.ToDegMinSec(),
                coordinate.IsNegative ? 'W' : 'E');
        }

        public static string ToDegMinSec(this GeoCoordinate coordinate)
        {
            return string.Format(
                "{0}° {1:00}' {2:00}\".{3:000}",
                coordinate.Degrees,
                coordinate.Minutes,
                coordinate.Seconds,
                coordinate.Milliseconds);
        }
    }
}