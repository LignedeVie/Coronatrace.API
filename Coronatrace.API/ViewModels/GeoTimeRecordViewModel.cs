using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coronatrace.API.ViewModels
{
    public class GeoTimeRecordViewModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double VerticalAccuracy { get; set; }
        public double HorizontalAccuracy { get; set; }
        public DateTime Time { get; set; }
    }
}
