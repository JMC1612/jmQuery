using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JmcAs400Query
{
    public static class CsvManager
    {
        public static string CreateCsvContent(DataTable data, char seperator = ';')
        {
            var csvContent = new StringBuilder();

            csvContent.AppendLine(string.Join(seperator, data.Columns.Cast<DataColumn>().Select(c => Escape(c.ColumnName, seperator))));

            foreach (DataRow row in data.Rows)
            {
                csvContent.AppendLine(string.Join(seperator, row.ItemArray.Select(field => Escape(field?.ToString() ?? string.Empty, seperator))));
            }

            return csvContent.ToString();
        }

        private static string Escape(string field, char seperator)
        {
            if(field.Contains(seperator) || field.Contains("\"") || field.Contains("\n"))
            {
                field = "\"" + field.Replace("\"", "\"\"") + "\"";
            }
            return field;
        }
    }
}
