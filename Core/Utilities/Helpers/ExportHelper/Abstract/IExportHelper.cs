using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.ExportHelper.Abstract
{
    public interface IExportHelper
    {
        public bool Export<T>(List<T> list, string filePath, string fileName);
    }
}
