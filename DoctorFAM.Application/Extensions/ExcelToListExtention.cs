using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using OfficeOpenXml.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Extensions
{
    public static class ExcelToListExtention
    {
        public async static Task<ExcelWorksheet> ExcelToList(this IFormFile ExcelFile)
        {
            //Get Count Of Properties From Inmcoming Table As <T> 
            //var countProperties = typeof(T).GetProperties().Count();

            using (var stream = new MemoryStream())
            {
                await ExcelFile.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
                    //var rowCount = workSheet.Dimension.Rows;

                    return workSheet;
                }
            }

            return null;
        }
    }
}

