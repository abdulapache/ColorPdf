using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Text;
using PersonalModel.Models;

namespace PersonalApp.Api
{
    public class ReadPdfGenrateController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public ReadPdfGenrateController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("api/PdfColorFile")]
        public IActionResult SendToCustomerAecb(PdfColorRequest request)
        {
            string uploadedFilesDirectory = Path.Combine(_environment.WebRootPath, "UploadedFiles");
            string processedFilesDirectory = Path.Combine(_environment.WebRootPath, "ProcessedPDF");

            try
            {
                // Generate a unique file name for the processed PDF
                string newFileName = $"{Guid.NewGuid()}.pdf";
                string newFilePath = Path.Combine(processedFilesDirectory, newFileName);

                // Load the original PDF file
                string pdfTempPath = Path.Combine(uploadedFilesDirectory, "temp.pdf");
                using (PdfReader pdfReader = new PdfReader(pdfTempPath))
                {
                    // Create a new PDF file with modified text color
                    using (FileStream newFileStream = new FileStream(newFilePath, FileMode.Create))
                    {
                        using (PdfStamper pdfStamper = new PdfStamper(pdfReader, newFileStream))
                        {
                            // Set the text color to blue
                            BaseColor blueColor = BaseColor.BLUE;

                            // Iterate through each page
                            for (int i = 1; i <= pdfReader.NumberOfPages; i++)
                            {
                                // Get the page content
                                PdfDictionary page = pdfReader.GetPageN(i);
                                PdfArray contentArray = page.GetAsArray(PdfName.CONTENTS);

                                if (contentArray != null)
                                {
                                    // Iterate through the content array
                                    for (int j = 0; j < contentArray.Size; j++)
                                    {
                                        // Get the content stream
                                        PdfObject contentObject = contentArray.GetDirectObject(j);
                                        if (contentObject is PRStream stream)
                                        {
                                            // Read the content stream
                                            byte[] data = PdfReader.GetStreamBytes(stream);
                                            string contentString = Encoding.UTF8.GetString(data);

                                            // Replace color operators with blue
                                            contentString = contentString.Replace("rg", "0 0 1 rg"); // Set fill color to blue (RGB)

                                            // Update the content stream
                                            data = Encoding.UTF8.GetBytes(contentString);
                                            stream.SetData(data);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Return the processed PDF file
                byte[] fileBytes = System.IO.File.ReadAllBytes(newFilePath);
                return File(fileBytes, "application/pdf", newFileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = false, message = "Error: " + ex.Message, filePath = "" });
            }
        }
    }
}
