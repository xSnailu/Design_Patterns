﻿//This file contains fragments that You have to fulfill

using BigTask2.Api;
using BigTask2.DataIterator;
using BigTask2.DataRouteIterator;
using System.Collections.Generic;

namespace BigTask2.Data
{
	class AdjacencyListDatabase : IGraphDatabase
    {
		private Dictionary<string, City> cityDictionary = new Dictionary<string, City>();
		private Dictionary<City, List<Route>> routes = new Dictionary<City, List<Route>>();
		
		private void AddCity(City city)
		{
			if (!cityDictionary.ContainsKey(city.Name))
				cityDictionary[city.Name] = city;
		}
		public AdjacencyListDatabase(IEnumerable<Route> routes)
		{
			foreach(Route route in routes)
			{
				AddCity(route.From);
				AddCity(route.To);
				if (!this.routes.ContainsKey(route.From))
				{
					this.routes[route.From] = new List<Route>();
				}
				this.routes[route.From].Add(route);
			}
		}
		public AdjacencyListDatabase()
		{
		}
		public void AddRoute(City from, City to, double cost, double travelTime, VehicleType vehicle)
		{
			AddCity(from);
			AddCity(to);
			if (!routes.ContainsKey(from))
			{
				routes[from] = new List<Route>();
			}
			routes[from].Add(new Route { From = from, To = to, Cost = cost, TravelTime = travelTime, VehicleType = vehicle});
		}
		public IDataIRoutesIterator GetRoutesIterator(City from)
		{
			return new AdjacencyListDatabaseRoutesIterator(cityDictionary, routes, from.Name);
		}
		public List<Route> GetRoutesFrom(City from)
		{
			List<Route> outputList = new List<Route>();
			/*
			 * Fill this fragment and return Type.
			 * Modyfing existing code in this class is forbidden.
			 * Adding new elements (fields, private classes) to this class is allowed.
			 */

			IDataIRoutesIterator routesIterator = GetRoutesIterator(from);
			while (routesIterator.TryNextRoute())
			{
				outputList.Add(routesIterator.GetCurrentRoute());
			}
			return outputList;
		}

		public City GetByName(string cityName)
		{
			return cityDictionary.GetValueOrDefault(cityName);
		}
	}
}
