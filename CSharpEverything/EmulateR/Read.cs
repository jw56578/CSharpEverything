using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Data;

namespace EmulateR
{
    public static class Read
    {
        /// <summary>
        /// emulating this by populating a datatable is extremely slow and takes so much memory
        /// </summary>
        /// <param name="path"></param>
        /// <param name="seperator"></param>
        public static DataTable Csv2(string path,string seperator)
        {
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.CommentTokens = new string[] { "#" };
                parser.SetDelimiters(new string[] { seperator });
                parser.HasFieldsEnclosedInQuotes = true;
                DataTable dt = new DataTable();
                // Skip over header line.
                string[] fields = parser.ReadFields();
                foreach (var f in fields)
                {
                    dt.Columns.Add(new DataColumn(f));
                }
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    var row = dt.NewRow();
                    dt.Rows.Add(fields);
                }
                return dt;
            }
        }
    }
}
