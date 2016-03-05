using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmulateR.Functions;
namespace EmulateR
{
    class Program
    {
        static void Main(string[] args)
        {
            var dt = Read.Csv2("Flights.csv", ",");

            Console.WriteLine(NRow(dt));

            var subset = Subset(dt, new string[] { "DEST" },"LAX","ATL","ORD","DFW","JFK","SFO","CLT","LAS","PHX") as DataTable;

            
            Console.WriteLine(subset.Rows.Count);

            Head(subset, 2);
            Console.Read();
        }
    }
}
