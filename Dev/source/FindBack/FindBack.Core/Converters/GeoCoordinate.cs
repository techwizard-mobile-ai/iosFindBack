using System;

namespace FindBack.Core.Converters
{
    public class GeoCoordinate
    {
        public bool IsNegative { get; set; }
        public int Degrees { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Milliseconds { get; set; }
        
        public static GeoCoordinate FromDouble(double? angleInDegrees)
        {
            if (!angleInDegrees.HasValue || angleInDegrees > 180 || angleInDegrees < -180)
            {
                return null;
            }

            var result = new GeoCoordinate();

            result.IsNegative = angleInDegrees < 0;
            angleInDegrees = Math.Abs(angleInDegrees.Value);

            result.Degrees = (int)Math.Floor(angleInDegrees.Value);
            var delta = angleInDegrees - result.Degrees;

            var seconds = (int)Math.Floor(3600.0 * delta.Value);
            result.Seconds = seconds % 60;
            result.Minutes = (int)Math.Floor(seconds / 60.0);
            delta = delta * 3600.0 - seconds;

            result.Milliseconds = (int)(1000.0 * delta);

            return result;
        }

        public string ToLatitude()
        {
            return string.Format(
                "{0} {1}",
                this.ToDegMinSec(),
                this.IsNegative ? 'S' : 'N');
        }

        public string ToLongitude()
        {
            return string.Format(
                "{0} {1}",
                this.ToDegMinSec(),
                this.IsNegative ? 'W' : 'E');
        }

        private string ToDegMinSec()
        {
            return string.Format(
                "{0}° {1:00}' {2:00}\".{3:000}",
                this.Degrees,
                this.Minutes,
                this.Seconds,
                this.Milliseconds);
        }
    }
}