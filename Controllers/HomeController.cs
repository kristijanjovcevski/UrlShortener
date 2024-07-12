using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Diagnostics;
using System.Drawing.Imaging;
using UrlShortener.Models;
using UrlShortener.Service;

namespace UrlShortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShortenerService _shortenerService;

        public HomeController (ILogger<HomeController> logger, ShortenerService shortenerService)
        {
            _logger = logger;
            _shortenerService = shortenerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenerateLink(string fullLink)
        {
            if (fullLink != null)
            {
                ViewData["ShortenedLink"] = _shortenerService.GenerateShortenedLink();
                ViewData["FullLink"] = fullLink;
            }


            
            return View("Index");
        }


        [HttpPost]
        public FileContentResult GenerateQRCode(string URL)
        {
            if (URL != null)
            {
                using (var qrGenerator = new QRCodeGenerator())
                {
                    var qrCodeData = qrGenerator.CreateQrCode(URL, QRCodeGenerator.ECCLevel.Q);
                    var qrCode = new QRCode(qrCodeData);

                    var qrCodeImage = qrCode.GetGraphic(20);


                    using (var stream = new MemoryStream())
                    {
                        qrCodeImage.Save(stream, ImageFormat.Png);
                        stream.Position = 0;

                        string qrCodeImageUrl = "/QrCode/GetQRCodeImage";

                        ViewBag.QRCodeImageUrl = qrCodeImageUrl;

                        return File(stream.ToArray(), "image/png");
                    }

                }
            }

            return null;
            
        }


        //[HttpGet("/QrCode/GetQRCodeImage")]
        //public IActionResult GetQRCodeImage()
        //{
        //    // Example: Retrieve the QR code image from a file, database, or memory
        //    byte[] imageData; // Replace with actual retrieval logic

        //    // Load or generate the QR code image data
        //    using (var qrGenerator = new QRCodeGenerator())
        //    {
        //        var qrCodeData = qrGenerator.CreateQrCode("example.com", QRCodeGenerator.ECCLevel.Q);
        //        var qrCode = new QRCode(qrCodeData);
        //        var qrCodeImage = qrCode.GetGraphic(20);

        //        using (var stream = new MemoryStream())
        //        {
        //            qrCodeImage.Save(stream, ImageFormat.Png);
        //            imageData = stream.ToArray();
        //        }
        //    }

        //    // Return the QR code image as a FileContentResult
        //    return File(imageData, "image/png");
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
