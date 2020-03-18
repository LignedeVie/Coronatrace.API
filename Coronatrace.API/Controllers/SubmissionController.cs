using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coronatrace.API.Models;
using Coronatrace.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace Coronatrace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly CoronatraceContext _context;

        public SubmissionController(CoronatraceContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("SendData")]
        public async Task<string> SendSubmission(List<GeoTimeRecordViewModel> viewModels)
        {
            if (viewModels == null)
                throw new ArgumentNullException(nameof(viewModels));

            var guid = Guid.NewGuid();
            var records = viewModels.Select(x => new GeoTimeRecord()
            {
                UserId = guid,
                Location = new Point(x.Latitude, x.Longitude),
                VerticalAccuracy = x.VerticalAccuracy,
                HorizontalAccuracy = x.HorizontalAccuracy,
                Time = x.Time,
                IsVerified = false
            });

            await this._context.GeoTimeRecords.AddRangeAsync(records);
            await this._context.SaveChangesAsync();

            return guid.ToString();
        }

        [HttpPost]
        [Route("SendVerification")]
        public async Task SendVerification(string userId, [FromForm] IFormFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            var verificationFile = new VerificationFile()
            {
                UserId = userId,
                FileName = file.FileName
            };

            await this._context.Files.AddAsync(verificationFile);
            await this._context.SaveChangesAsync();
        }
    }
}