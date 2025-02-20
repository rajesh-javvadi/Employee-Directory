using DinkToPdf;
using DinkToPdf.Contracts;
using Employee_Directory.Models;


namespace Employee_Directory.Services
{
    public class PdfServices
    {
        private readonly IConverter _pdfConverter;
        public PdfServices(IConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        public byte[] GeneratePdf(List<Employee> employees)
        {
            string htmlContent = $@"
                    <html>
                        <head>
                            <style>
                                table {{
                                    width: 100%;
                                    border-collapse: collapse;
                                    table-layout: fixed;
                                }}
                                th, td {{
                                    padding: 8px;
                                    text-align: left;
                                    border: 1px solid #ddd;
                                   word-wrap: break-word;
                                }}
                                th {{
                                    background-color: #f2f2f2;
                                }}
                                thead {{
                                    display: table-header-group;
                                }}
                                tr {{
                                    page-break-inside: avoid;
                                }}
                            </style>
                        </head>
                        <body>
                            <h1 style='text-align:center'>Employee Data</h1>
                           <table>
                                <colgroup>
                                    <col style='width: 10%'/>
                                   <col style='width: 10%'/>
                                   <col style='width: 20%'/>
                                   <col style='width: 15%'/>
                                   <col style='width: 15%'/>
                                   <col style='width: 10%'/>
                                   <col style='width: 10%'/>
                                   <col style='width: 10%'/>
                                   <col style='width: 10%'/>
                                </colgroup>
                                <thead>
                                    <tr>
                                        <th>First Name</th>
                                        <th>Last Name</th>
                                        <th>Email</th>
                                        <th>Preferred Name</th>
                                        <th>Job Title</th>
                                        <th>Office</th>
                                        <th>Department</th>
                                       <th>Phone Number</th>
                                        <th>Skype Id</th>
                                   </tr>
                                </thead>
                                <tbody>";
            foreach (var employee in employees)
            {
                htmlContent += $@"
                <tr>
                    <td>{employee.FirstName}</td>
                    <td>{employee.LastName}</td>
                    <td>{employee.Email}</td>
                    <td>{employee.PreferredName}</td>
                    <td>{employee.JobTitle}</td>
                    <td>{employee.Office}</td>
                    <td>{employee.Department}</td>
                    <td>{employee.PhoneNumber}</td>
                    <td>{employee.SkypeId}</td>
                </tr>";
            }
            htmlContent += @"
                    </tbody>
                     </table>
                 </body>
                </html>";

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 20, Bottom = 10, Left = 10, Right = 10 }
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            byte[] pdfBytes = _pdfConverter.Convert(pdf);
            return pdfBytes;
        }

    }
}
