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
                string args = string.Format("/s /f /t {0}", delay);
                var psi = new ProcessStartInfo()
                {
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    FileName = @"C:\Windows\SysWOW64\shutdown.exe",
                    Arguments = args
                };
                Process.Start(psi);
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
