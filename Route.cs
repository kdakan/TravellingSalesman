using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TravellingSalesmanCore
{
    public class Route
    {
        public List<Location> Locations { get; }
        public int Length { get { return length; } }
        private int length;
        private void calculateLength()
        {
            length = 0;
            if (Locations.Count <= 1)
                return;

            for (int i = 0; i < Locations.Count - 1; i++)
                length += Locations[i].GetDistanceTo(Locations[i + 1]);
        }

        public void Print()
        {
            Console.WriteLine(string.Join("->", Locations.Select(x => x.Name)) + $" {Length} m.");
        }

        public Route(List<Location> locations)
        {
            Locations = locations;
            calculateLength();
        }

        public Route TwoOptSwap(int i, int k)
        {
            //reverse the subpart from index i to k
            var locations = new List<Location>(Locations);
            locations.Reverse(i, k - i + 1);
            return new Route(locations);
        }
    }
}
