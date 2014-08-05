using Needles.Attributes;

namespace Needles.Tests.Types
{
    public class Location
    {
        public readonly IGeolocatorBase Geolocator;
        public readonly MapBase Map;

        public Location([Manual] IGeolocatorBase geolocator, [Manual] MapBase map)
        {
            Geolocator = geolocator;
            Map = map;
        }
    }
}