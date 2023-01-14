using ClosedXML.Excel;
using Core.Utilities.Helpers.ExportHelper.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.ExportHelper.Concrete
{
    public class ExporExcelHelper : IExportHelper
    {
        public bool Export<T>(List<T> list, string filePath, string fileName)
        {
            bool exported = false;
            using (IXLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(fileName).FirstCell().InsertTable<T>(list, false);

                workbook.SaveAs(filePath + fileName + ".xlsx");
                exported = true;
            }

            return exported;
        }
    }
}
