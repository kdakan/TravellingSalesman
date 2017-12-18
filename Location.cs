using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TravellingSalesmanCore
{
    public class Location
    {
        public string Name { get; }
        public string Address { get; }
        public Dictionary<Location, int> distancesToDic { get; set; }
        public int GetDistanceTo(Location to)
        {
            return distancesToDic[to];
        }

        public Location FindNearestUnvisitedNeighbor(HashSet<Location> visitedSet)
        {
            var nearestUnvisitedNeighbour = distancesToDic.Where(entry => !visitedSet.Contains(entry.Key)).OrderBy(d => d.Value).First().Key;
            return nearestUnvisitedNeighbour;
        }

        public Location(string name, string address)
        {
            Name = name;
            Address = address;
        }

    }

}
