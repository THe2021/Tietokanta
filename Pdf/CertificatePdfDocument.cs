using DataBaseA.Models;
using DataBaseA.Services;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Drawing;
using System.IO;
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

        private byte[] BitmapToBytes(Bitmap bitmap)
        {
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }


        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(40);

                var logoBytes = BitmapToBytes(DataBaseA.Properties.Resources.thumbnail_image001);

                page.Header().Row(row =>
                {
                    row.ConstantItem(120)
                       .Height(60)
                       .Image(logoBytes)
                       .FitArea();

                    row.RelativeItem().AlignCenter().Column(col =>
                    {
                        col.Item().Text("WELDER QUALIFICATION CERTIFICATE")
                            .SemiBold().FontSize(20);

                        col.Item().Text($"Welder: {_certificate.WelderName}").FontSize(14);
                        col.Item().Text($"Welder ID: {_certificate.WelderCode}").FontSize(14);
                        col.Item().Text($"Employer: {_certificate.Employer}").FontSize(14);
                 
                    });
                });

                page.Content().Column(column =>
                {
                    column.Spacing(15);

                    // CERTIFICATE INFO
                    column.Item().Text("Certificate Information").Bold().FontSize(14);

                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(c =>
                        {
                            c.RelativeColumn();
                            c.RelativeColumn();
                        });

                        void Cell(string label, string value)
                        {
                            table.Cell().Padding(4).Text(label).SemiBold();
                            table.Cell().Padding(4).Text(value);
                        }

                        Cell("Certificate", _certificate.CertificateName);
                        Cell("Authority", _certificate.IssuingAuthority);
                        Cell("Issue Date", _certificate.IssueDate.ToString("dd.MM.yyyy"));
                        Cell("Expiry Date", _certificate.ExpiryDate.ToString("dd.MM.yyyy"));
                        Cell("Product Type", _certificate.ProductType);
                        Cell("Welding Position", _certificate.WeldingPosition);

                    });

                    column.Item().LineHorizontal(1);

                    // QUALIFICATION RANGE
                    column.Item().Text("Qualification Range").Bold().FontSize(14);

                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(c =>
                        {
                            c.RelativeColumn();
                            c.RelativeColumn();
                        });

                        void Cell(string label, string value)
                        {
                            table.Cell().Padding(4).Text(label).SemiBold();
                            table.Cell().Padding(4).Text(value);
                        }

                        Cell("Material Thickness", _certificate.MaterialThickness?.ToString());
                        Cell("Pipe Diameter", _certificate.PipeDiameter?.ToString());
                    });

                    column.Item().LineHorizontal(1);

                    // WELDING PROCESSES
                    column.Item().Text("Welding Process Details").Bold().FontSize(14);

                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1); // Process
                            columns.RelativeColumn(1); // Filler group
                            columns.RelativeColumn(2); // Designation
                            columns.RelativeColumn(1); // Polarity
                            columns.RelativeColumn(1); // Gas
                            columns.RelativeColumn(1); // Aux
                            columns.RelativeColumn(1); // Multilayer
                        });

                        table.Header(header =>
                        {
                            header.Cell().Padding(4).Text("Process").Bold();
                            header.Cell().Padding(4).Text("Filler Group").Bold();
                            header.Cell().Padding(4).Text("Filler Designation").Bold();
                            header.Cell().Padding(4).Text("Polarity").Bold();
                            header.Cell().Padding(4).Text("Gas").Bold();
                            header.Cell().Padding(4).Text("Aux").Bold();
                            header.Cell().Padding(4).Text("Multilayer").Bold();
                        });

                        foreach (var process in _certificate.Processes)
                        {
                            table.Cell().Padding(4).Text(process.ProcessCode);
                            table.Cell().Padding(4).Text(process.FillerMaterialGroup);
                            table.Cell().Padding(4).Text(process.FillerMaterialDesignation);
                            table.Cell().Padding(4).Text(process.Polarity);
                            table.Cell().Padding(4).Text(process.ShieldingGas);
                            table.Cell().Padding(4).Text(process.Auxiliaries);
                            table.Cell().Padding(4).Text(process.IsMultilayer ? "Yes" : "No");
                        }
                    });

                    column.Item().LineHorizontal(1);

                    column.Item().Text($"Joint Types: {string.Join(", ", _certificate.JointTypes)}");
                    column.Item().Text($"Parent Materials: {string.Join(", ", _certificate.ParentMaterials)}");

                    column.Item().LineHorizontal(1);

                    // TEST SUPERVISION
                    column.Item().Text("Test Supervision").Bold().FontSize(14);

                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(c =>
                        {
                            c.RelativeColumn();
                            c.RelativeColumn();
                        });

                        void Cell(string label, string value)
                        {
                            table.Cell().Padding(4).Text(label).SemiBold();
                            table.Cell().Padding(4).Text(value);
                        }

                        Cell("Test Supervisor", _certificate.TestSupervisorName);
                        Cell("Examination Body", _certificate.ExaminationBody);
                        Cell("Remarks", _certificate.Remarks);
                    });

                    column.Item().PaddingTop(20);

                    // SIGNATURE AREA
                    column.Item().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("Examiner Signature").Bold();
                            col.Item().Text("____________________________");
                            col.Item().Text(_certificate.ExaminationSignature);
                        });

                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("Date").Bold();
                            col.Item().Text("____________________________");
                        });
                    });
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
