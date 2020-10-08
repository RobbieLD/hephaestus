using Hephaestus.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Hephaestus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScreenController : ControllerBase
    {
        private readonly ILoggingService _loggingService;

        public ScreenController(ILoggingService logger)
        {
            _loggingService = logger;
        }

        [HttpGet]
        public IActionResult Get(int width, int height)
        {
            _loggingService.LogInformation(string.Format("Screen Requested for resolution {0}x{1}", width, height));

            var bitmap = new Bitmap(1920, 1080);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(0, 0, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
            }

            using MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Jpeg);

            return File(stream.ToArray(), "image/jpeg");
        }
    }
}
