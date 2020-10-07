using Hephaestus.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hephaestus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly ILoggingService _loggingService;

        public StatusController(ILoggingService logger)
        {
            _loggingService = logger;
        }

        [HttpGet]
        public string Get()
        {
            _loggingService.LogInformation("Status Requested");

            return "Server Running";
        }
    }
}
