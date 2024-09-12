using System.Reflection;
using CefSharp.OffScreen;
using CefSharp;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
namespace ClassLibrary1
{
    public class Class1
    {
        public MemoryStream CreatePdfFileFromBaseHtmlFile(string URL)
        {
            try
            {
                HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.Cef);
                CefConverterSettings cefConverterSettings = new CefConverterSettings();
                //Set Blink viewport size.
                cefConverterSettings.ViewPortSize = new Syncfusion.Drawing.Size(1280, 0);
               
                //Assign Blink converter settings to HTML converter.
                htmlConverter.ConverterSettings = cefConverterSettings;
                using (PdfDocument document = htmlConverter.Convert(URL))
                {
                    MemoryStream stream = new MemoryStream();
                    document.Save(stream);
                    document.Close(true);
                    return stream;
                }                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while CreatePdfFileFromBaseHtmlFile");
            }
        }
    }
}