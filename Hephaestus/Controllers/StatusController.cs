using Hephaestus.Models;
using Hephaestus.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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

        [Route("hdd")]
        [HttpGet]
        public DriveStatus[] Hdd()
        {
            _loggingService.LogInformation("Hdd Requested");
            List<DriveStatus> statuses = new List<DriveStatus>();

            foreach(DriveInfo drive in DriveInfo.GetDrives())
            {
                long totalFree = drive.AvailableFreeSpace;
                long total = drive.TotalSize;
                double percentFull = Math.Round((double)(total - totalFree) / total * 100, 2);
                statuses.Add(new DriveStatus(drive.Name,
                    ByteSizeLib.ByteSize.FromBytes(totalFree).ToString(),
                    ByteSizeLib.ByteSize.FromBytes(total).ToString(),
                    percentFull));
            }

            return statuses.ToArray();
        }
    }
}
