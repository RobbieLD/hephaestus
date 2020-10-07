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

        [HttpGet]
        public string Get()
        {
            _loggingService.LogInformation("Shutdown Initiated");
            
            try
            {
                Process.Start("shutdown", "/s /t 1");
            } catch(Exception e)
            {
                _loggingService.LogError(e.Message);
                return e.Message;
            }

            return "Success";
        }

        private void Shutdown()
        {
            var psi = new ProcessStartInfo("shutdown", "/s /t 1");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
    }
}
