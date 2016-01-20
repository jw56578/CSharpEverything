using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            input = Console.ReadLine();
            string[] info = input.Split(" ".ToCharArray());
            var numberOfCities = info[0];
            var costPerMiles = int.Parse(info[1]);
            var factorOfDecline = float.Parse(info[2]);
            var salesManCostPerMile = 1;
            List<CitySale> cities = new List<CitySale>();

            while (!string.IsNullOrEmpty((input = Console.ReadLine())))
            {
                info = input.Split(" ".ToCharArray());
                cities.Add(new CitySale() {
                    X = int.Parse(info[0]),
                    Y = int.Parse(info[1]),
                    Price = int.Parse(info[2]),
                });
            }


        }
    }

    public struct CitySale
    {
        public int Id;
        public int X;
        public int Y;
        public int Price;
        public List<CitySale> links;

    }
}
