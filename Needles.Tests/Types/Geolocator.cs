namespace Needles.Tests.Types
{
    public interface IGeolocatorBase
    {
        
    }

    public interface IGeolocator : IGeolocatorBase
    {
    }

    public class Geolocator : IGeolocator
    {
    }

    public class GeolocatorLocal : IGeolocator
    {
        
    }
}