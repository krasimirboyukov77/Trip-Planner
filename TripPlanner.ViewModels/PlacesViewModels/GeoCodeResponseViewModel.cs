using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.ViewModels.PlacesViewModels
{

        public class GeocodeResponse
        {
            public List<GeocodeResult> results { get; set; }
        }

        public class GeocodeResult
        {
        public Geometry geometry { get; set; } = null!;
        }

        public class Geometry
        {
            public Location location { get; set; } = null!;
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
}
