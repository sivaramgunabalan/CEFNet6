using CefSharp;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace HTMLToPDFWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HtmlToPdfController : ControllerBase
    {
        private readonly ILogger<HtmlToPdfController> _logger;

        public HtmlToPdfController(ILogger<HtmlToPdfController> logger)
        {
            _logger = logger;
        }
        [HttpPost(Name = "pdf")]
        public IActionResult ExportToPdf([FromBody] PdfRequest request)
        {
            ClassLibrary1.Class1 class1 = new ClassLibrary1.Class1();

            string pdfFileName = "Output.pdf";

            if (string.IsNullOrEmpty(request.Url))
            {
                request.Url = "https://www.google.com";
            }

            //Convert URL to PDF.
            MemoryStream stream = class1.CreatePdfFileFromBaseHtmlFile(request.Url);
            stream.Position = 0;
                return File(stream, "application/pdf", pdfFileName);
            
        }
    }
    public class PdfRequest
    {
        public string Url { get; set; }
    }
}
