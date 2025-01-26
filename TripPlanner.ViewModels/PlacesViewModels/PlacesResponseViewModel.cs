using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.ViewModels.PlacesViewModels
{
    public class PlacesResponse
    {
        public List<PlaceResult> results { get; set; }
    }

    public class PlaceResult
    {
        public string name { get; set; }
        public string vicinity { get; set; }
        public Geometry geometry { get; set; }
        public List<Photo> photos { get; set; }

        // Add the image URL property
        public string ImageUrl { get; set; }
    }

    public class Photo
    {
        public string photo_reference { get; set; }
    }
}
