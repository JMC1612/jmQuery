using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JmcAs400Query
{
    public static class CsvManager
    {
        public static char userDefindedDilimiter = '|';

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

        public static DataTable LoadDataTableFromCsvStatic(string filePath, char delimiter = ',')
        {
            DataTable dt = new DataTable();
            using (var reader = new StreamReader(filePath))
            {
                bool isHeader = true;
                string? line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(delimiter);

                    if (isHeader)
                    {
                        foreach (var header in values)
                        {
                            dt.Columns.Add(header.Trim());
                        }
                        isHeader = false;
                    }
                    else
                    {
                        dt.Rows.Add(values);
                    }
                }
            }
            dt.TableName = Path.GetFileNameWithoutExtension(filePath);
            return dt;
        }

        public static DataTable LoadDataTableFromCsv(string filePath)
        {
            DataTable dt = new DataTable();
            using (var reader = new StreamReader(filePath))
            {
                bool isHeader = true;
                char delimiter = ',';
                string? line;

                while ((line = reader.ReadLine()) != null)
                {

                    // get delimiter
                    if (isHeader) {
                        if (line.Contains(userDefindedDilimiter))
                        {
                            delimiter = userDefindedDilimiter;
                            Debug.WriteLine("User delimiter used.");
                        }
                        if (line.Contains(','))
                        {
                            delimiter = ',';
                        } else if (line.Contains(';'))
                        {
                            delimiter = ';';
                        }
                        Debug.WriteLine("Load CSV with dilimiter: " + userDefindedDilimiter);
                    }

                    string[] values = line.Split(delimiter);

                    if (isHeader)
                    {
                        foreach (var header in values)
                        {
                            dt.Columns.Add(header.Trim());
                        }
                        isHeader = false;
                    }
                    else
                    {
                        dt.Rows.Add(values);
                    }
                }
            }
            dt.TableName = Path.GetFileNameWithoutExtension(filePath);
            return dt;
        }
    }
}
