using DataBaseA.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Xml.Linq;

namespace DataBaseA.Pdf
{
    public class CertificatePdfDocument : IDocument
    {
        private readonly CertificateModel _certificate;

        public CertificatePdfDocument(CertificateModel certificate)
        {
            _certificate = certificate;
        }

        public DocumentMetadata GetMetadata()
        {
            return DocumentMetadata.Default;
        }

        public DocumentSettings GetSettings()
        {
            return DocumentSettings.Default;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(40);

                page.Header()
                    .Text("WELDER QUALIFICATION CERTIFICATE")
                    .SemiBold().FontSize(18).AlignCenter();

                page.Content().Column(column =>
                {
                    column.Spacing(10);

                    column.Item().Text($"Certificate: {_certificate.CertificateName}");
                    column.Item().Text($"Authority: {_certificate.IssuingAuthority}");
                    column.Item().Text($"Issue Date: {_certificate.IssueDate:dd.MM.yyyy}");
                    column.Item().Text($"Expiry Date: {_certificate.ExpiryDate:dd.MM.yyyy}");
                    column.Item().Text($"Welding Position: {_certificate.WeldingPosition}");
                    column.Item().Text($"Product Type: {_certificate.ProductType}");

                    column.Item().LineHorizontal(1);

                    column.Item().Text("Welding Processes").Bold();

                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("Process").Bold();
                            header.Cell().Text("Filler Group").Bold();
                            header.Cell().Text("Shielding Gas").Bold();
                        });

                        foreach (var process in _certificate.Processes)
                        {
                            table.Cell().Text(process.ProcessCode);
                            table.Cell().Text(process.FillerMaterialGroup);
                            table.Cell().Text(process.ShieldingGas);
                        }
                    });

                    column.Item().LineHorizontal(1);

                    column.Item().Text("Signature").Bold();
                    column.Item().Text("_______________________________");
                });

                page.Footer()
                    .AlignCenter()
                    .Text(text =>
                    {
                        text.Span("Generated on ");
                        text.Span(DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                    });
            });
        }
    }
}