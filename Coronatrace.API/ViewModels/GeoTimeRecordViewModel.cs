using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coronatrace.API.ViewModels
{
    public class GeoTimeRecordViewModel
    {
        public Point Location { get; set; }
        public DateTime Time { get; set; }
    }
}
