using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCMiniGenericsEventsLibrary
{
    public class DataAccess<T> where T: new()
    {
        public void SaveToCsv(List<T> items, string filePath)
        {
            T entry = new T();
            List<string> rows = new List<string>();
            var columns = entry.GetType().GetProperties();
            string row = string.Empty;

            foreach (var column in columns)
            {
                row += $"{column.Name},";
            }

            row = row.TrimEnd(',');
            rows.Add(row);

            foreach (var item in items)
            {
                row = string.Empty;
                bool isBadWord = false;

                foreach (var column in columns)
                {
                    string value = column.GetValue(item).ToString();
                    isBadWord = BadWordChecker.BadWordCheck(value);

                    if (isBadWord)
                    {
                        break;
                    }

                    row += $"{value},";
                }

                if (!isBadWord)
                {
                    row = row.TrimEnd(',');
                    rows.Add(row);
                }
            }

            File.WriteAllLines(filePath, rows);
        }
    }
}
