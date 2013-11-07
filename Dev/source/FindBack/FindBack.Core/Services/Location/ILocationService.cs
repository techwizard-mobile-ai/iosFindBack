namespace FindBack.Core.Services.Location
{
    public interface ILocationService
    {
        bool TryGetLatestLocation(out double latitude, out double longitude);
    }
}