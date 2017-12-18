using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TravellingSalesmanCore
{
    public class TravellingSalesmanProblem
    {
        private List<Location> locations;

        private const string apiKey = "AIzaSyAPVVAMDDxzKUtishmm4OYJHp5meKsID34";
        private int googleMapsDistance(string from, string to)
        {
            string url = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={from}&destinations={to}&key={apiKey}";

            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var data = response.GetResponseStream();
            var reader = new StreamReader(data);
            var jsonResult = reader.ReadToEnd();
            response.Close();
            dynamic result = JsonConvert.DeserializeObject(jsonResult);

            return ((int)result.rows[0].elements[0].distance.value.Value);
        }

        public TravellingSalesmanProblem(List<Location> locations)
        {
            this.locations = locations;
            Console.WriteLine("Distances:");
            foreach (var location in locations)
            {
                location.distancesToDic = new Dictionary<Location, int>();
                foreach (var otherLocation in locations.Where(x => x != location))
                {
                    var distance = googleMapsDistance(location.Address, otherLocation.Address);
                    location.distancesToDic.Add(otherLocation, distance);
                    Console.WriteLine($"{location.Name} -> {otherLocation.Name} : {distance} m.");
                }
            }
        }

        //private Route initializeRandomRoute()
        //{
        //    return new Route(new List<Location>(locations));
        //}

        private Route initializeNearestNeighborRoute()
        {
            var nnVisitedSet = new HashSet<Location>();
            var nnRouteLocations = new List<Location>();
            nnRouteLocations.Add(locations[0]);
            nnVisitedSet.Add(locations[0]);
            for (int i = 0; i < locations.Count - 1; i++)
            {
                var nearestUnvisitedNeighbor = nnRouteLocations[i].FindNearestUnvisitedNeighbor(nnVisitedSet);
                nnRouteLocations.Add(nearestUnvisitedNeighbor);
                nnVisitedSet.Add(nearestUnvisitedNeighbor);
            }

            return new Route(new List<Location>(nnRouteLocations));
        }

        public Route Solve()
        {
            var startTime = DateTime.Now;

            var existingRoute = initializeNearestNeighborRoute();
            var count = locations.Count;
            Console.Write($"Initial route:");
            existingRoute.Print();

            var anyImprovement = true;
            while (anyImprovement)
            {
                anyImprovement = false;
                for (int i = 1; i < count - 1; i++)
                {
                    for (int k = i + 1; k < count; k++)
                    {
                        //Console.Write($"trying {i}, {k} ");
                        var newRoute = existingRoute.TwoOptSwap(i, k);
                        //newRoute.Print();
                        if (newRoute.Length < existingRoute.Length)
                        {
                            anyImprovement = true;
                            existingRoute = newRoute;
                            Console.Write($"Improved route ({i},{k}):");
                            newRoute.Print();
                            break;
                        }
                    }
                    if (anyImprovement)
                        break;
                }
            }

            //https://en.wikipedia.org/wiki/2-opt
            //repeat until no improvement is made {
            //    start_again:
            //    best_distance = calculateTotalDistance(existing_route)
            //    for (i = 1; i < number of nodes eligible to be swapped - 1; i++) {
            //        for (k = i + 1; k < number of nodes eligible to be swapped; k++) {
            //            new_route = 2optSwap(existing_route, i, k)
            //            new_distance = calculateTotalDistance(new_route)
            //            if (new_distance < best_distance)
            //            {
            //              existing_route = new_route
            //              goto start_again
            //            }
            //        }
            //    }
            //}

            //Console.Write("Result: ");
            //existingRoute.Print();
            var finishTime = DateTime.Now;
            var duration = finishTime - startTime;
            Console.WriteLine($"Started at: {startTime}, finished at {finishTime}, took {duration.Seconds} seconds");
            return existingRoute;
        }
    }
}
