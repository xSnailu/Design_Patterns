﻿//This file contains fragments that You have to fulfill

using BigTask2.Api;
using BigTask2.Data;
using System;
using System.Collections.Generic;

namespace BigTask2.Algorithms
{
	public abstract class Dijkstra : IAlgorithm
	{
		public IEnumerable<Route> Solve(IGraphDatabase graph, City from, City to)
		{
			Dictionary<City, (double dist, Route last)> distances = new Dictionary<City, (double dist, Route last)>();
			HashSet<City> visitedCitites = new HashSet<City>();
			distances[from] = (0, null);
			City minCity = from;
			while (minCity != to)
			{
				List<Route> routesList = graph.GetRoutesFrom(minCity);
				/*
				 * For each outgoing route from minCity...
				 */
				foreach(Route route in routesList)
				{
					//Route route = null; /* Change to current Route*/
					if (visitedCitites.Contains(route.To))
					{
						continue;
					}
					double dist = distances[minCity].dist + OptimizingValueFunc(route);
					if (!distances.ContainsKey(route.To))
					{
						distances[route.To] = (dist, route);
					}
					else
					{
						if (dist < distances[route.To].dist)
						{
							distances[route.To] = (dist, route);
						}
					}
				}
				visitedCitites.Add(minCity);
				minCity = null;
				foreach (var (city, (dist, route)) in distances)
				{
					if (visitedCitites.Contains(city))
					{
						continue;
					}
					if (minCity == null || dist < distances[city].dist)
					{
						minCity = city;
					}
				}
				if (minCity == null)
				{
					return null;
				}
			}
			List<Route> result = new List<Route>();
			for (Route route = distances[to].last; route != null; route = distances[route.From].last)
			{
				result.Add(route);
			}
			result.Reverse();
			return result;
		}

        protected abstract double OptimizingValueFunc(Route route);
    }

    class DijkstraCost : Dijkstra
    {
        protected override double OptimizingValueFunc(Route route)
        {
            return route.Cost;
        }
    }

    class DijkstraTime : Dijkstra
    {
        protected override double OptimizingValueFunc(Route route)
        {
            return route.TravelTime;
        }
    }
}
