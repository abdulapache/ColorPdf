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
                    // Create a new PDF file with modified background
                    using (FileStream newFileStream = new FileStream(newFilePath, FileMode.Create))
                    {
                        using (PdfStamper pdfStamper = new PdfStamper(pdfReader, newFileStream))
                        {
                            // Set the background color with reduced opacity
                            BaseColor overlayColor = new BaseColor(0, 0, 255); // Blue color
                            PdfGState gState = new PdfGState();
                            gState.FillOpacity = 0.5f; // Adjust opacity as needed

                            for (int i = 1; i <= pdfReader.NumberOfPages; i++)
                            {
                                PdfContentByte contentByte = pdfStamper.GetOverContent(i);
                                contentByte.SaveState(); // Save graphics state
                                contentByte.SetGState(gState); // Apply opacity
                                contentByte.SetColorFill(overlayColor);
                                contentByte.Rectangle(0, 0, pdfReader.GetPageSize(i).Width, pdfReader.GetPageSize(i).Height);
                                contentByte.Fill();
                                contentByte.RestoreState(); // Restore graphics state
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
