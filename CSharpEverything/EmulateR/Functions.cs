using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulateR
{
    public static partial class Functions
    {
        public static long NRow(object thing)
        {
            var dt = thing as DataTable;
            if (dt != null)
                return dt.Rows.Count;
            return 0;
        }
        public static object Subset(object thing,string[] columns, params string[] values)
        {
            var dt = thing as DataTable;
            if (dt == null)
                return new DataTable();
            var clone = dt.Clone();
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (var column in columns)
            {
                foreach (var value in values)
                {
                    if (first == false)
                        sb.Append(" OR ");
                    sb.Append(column + "='" + value +"' ");
                    first = false;
                }
            }
            var rows = dt.Select(sb.ToString());
            foreach (var row in rows)
            {
                clone.Rows.Add(row.ItemArray);
            }
            return clone;
        }
        public static void AsInteger(object thing, int rows)
        {

        }
        public static void AsString(object thing, int rows)
        {

        }
        public static void AsFactor(object thing, int rows)
        {

        }
        public static void Head(object thing, int rows)
        {
            var dt = thing as DataTable;
            if (dt == null)
                return;
            foreach (DataColumn col in dt.Columns)
            {
                Console.Write(col.ColumnName + "  ");
            }
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    Console.Write(dt.Rows[i][col.ColumnName] + "  ");
                }
                
            }

        }
    }
}
