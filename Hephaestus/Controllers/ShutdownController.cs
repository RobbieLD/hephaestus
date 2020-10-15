using Hephaestus.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Hephaestus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShutdownController : ControllerBase
    {
        private readonly ILoggingService _loggingService;

        public ShutdownController(ILoggingService logger)
        {
            _loggingService = logger;
        }

        [HttpPost]
        public string Post([FromQuery] int delay)
        {
            _loggingService.LogInformation("Shutdown Initiated");
            
            try
            {
                _ = Process.Start(string.Format("shutdown", "/s /t {0}", delay));
            }
            catch (Exception e)
            {
                _loggingService.LogError(e.Message);
                return e.Message;
            }

            return "Success";
        }
    }
}
