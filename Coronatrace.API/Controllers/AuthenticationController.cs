using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coronatrace.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Coronatrace.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly CoronatraceContext _context;

        public AuthenticationController(ILogger<AuthenticationController> logger,
            CoronatraceContext context)
        {
            _logger = logger;
            this._context = context;
        }

        [HttpPost]
        public async Task<string> Register()
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
            };

            await this._context.Users.AddAsync(user);
            await this._context.SaveChangesAsync();

            return user.Id.ToString();
        }
    }
}
