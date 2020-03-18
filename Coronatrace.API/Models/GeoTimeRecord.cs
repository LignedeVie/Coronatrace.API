using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coronatrace.API.Models
{
    public class GeoTimeRecord
    {
        [Key]
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Time { get; set; }
        public Point Location { get; set; }
        public double HorizontalAccuracy { get; set; }
        public double VerticalAccuracy { get; set; }
        public bool IsVerified { get; set; }
        public DateTime VerifiedDateTime { get; internal set; }
    }
}
