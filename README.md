# Travelling Salesman .Net Core 2 Example

This is an exercise to solve the travelling salesman problem, namely, travelling all locations in the minimum l

## Algorithm details:

Since the optimal solution is o(n!) and practically not applicable to a large graph, in practice, heuristic methoods are used to find a near optimal solution instead.
In this solution, I used the nearest neighbor algorithm for the initial solution, then the 2-opt algorithm for improving this solution step by step, as described here: https://en.wikipedia.org/wiki/2-opt

```cs
repeat until no improvement is made {
    start_again:
    best_distance = calculateTotalDistance(existing_route)
    for (i = 1; i < number of nodes eligible to be swapped - 1; i++) {
        for (k = i + 1; k < number of nodes eligible to be swapped; k++) {
            new_route = 2optSwap(existing_route, i, k)
            new_distance = calculateTotalDistance(new_route)
            if (new_distance < best_distance)
            {
              existing_route = new_route
              goto start_again
            }
        }
    }
}
```

2optSwap(existing_route, i, k) simply reverses the part of the route starting from index i to index k

## Description of the classes in this solution:

* TravellingSalesmanProblem class defines the locations, finds the distances between each location using Google Maps api, and finds an efficient route using the algorith described above.

* Location class holds the name, address, and the distances to each of the other location in the graph, and finds the nearest unvisited neighbor location.

* Route class holds the travelled route as a List<Location> and computes the total length of the route.

