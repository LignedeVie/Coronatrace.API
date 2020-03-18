using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coronatrace.API.Models;
using Coronatrace.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coronatrace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly CoronatraceContext _context;

        public DataController(CoronatraceContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<GeoTimeRecordViewModel> GetContaminatedData(DateTime lastCheckedDate)
        {
            return this._context.GeoTimeRecords.Where(
                x => x.IsVerified
                && x.VerifiedDateTime > lastCheckedDate)
                .Select(x => new GeoTimeRecordViewModel()
                {
                    Latitude = x.Location.X,
                    Longitude = x.Location.Y,
                    HorizontalAccuracy = x.HorizontalAccuracy,
                    VerticalAccuracy = x.VerticalAccuracy,
                    Time = x.Time
                });
        }
    }
}