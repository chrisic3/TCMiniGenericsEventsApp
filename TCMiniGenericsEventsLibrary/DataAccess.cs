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
        public event EventHandler<T> BadEntryFound;

        public void SaveToCsv(List<T> items, string filePath)
        {
            T entry = new T();
            List<string> rows = new List<string>();
            var columns = entry.GetType().GetProperties(); // reflection to get properties of T
            string row = string.Empty;

            foreach (var column in columns)
            {
                row += $"{column.Name},";
            }

            row = row.TrimEnd(','); // remove trailing comma
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
                        BadEntryFound?.Invoke(this, item); // raise event for bad entry
                        break; // skip the rest of the columns for this item if a bad word is found
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
