using Hephaestus.Models;
using Hephaestus.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Hephaestus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILoggingService _logger;

        public LogController(ILoggingService logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public LogEntry[] Get()
        {
            return this._logger.Logs().ToArray();
        }

    }
}
