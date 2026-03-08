using DataBaseA.Models;
using DataBaseA.Pdf;
using QuestPDF.Fluent;
using System.Drawing;
using System.IO;

namespace DataBaseA.Services
{
    public class PdfService
    {
        public void GenerateCertificatePdf(CertificateModel certificate, string path)
        {
            var document = new CertificatePdfDocument(certificate);
            document.GeneratePdf(path);
        }

       
    }
}