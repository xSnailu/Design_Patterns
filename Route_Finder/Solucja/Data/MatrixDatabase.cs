﻿//This file contains fragments that You have to fulfill

using BigTask2.Api;
using BigTask2.DataIterator;
using System.Collections.Generic;
using System.Linq;

namespace BigTask2.Data
{
	class MatrixDatabase : IGraphDatabase
	{
		private Dictionary<City, int> cityIds = new Dictionary<City, int>();
		private Dictionary<string, City> cityDictionary = new Dictionary<string, City>();
		private List<List<Route>> routes = new List<List<Route>>();

		private void AddCity(City city)
		{
			if (!cityDictionary.ContainsKey(city.Name))
			{
				cityDictionary[city.Name] = city;
				cityIds[city] = cityIds.Count;
				foreach (var routes in routes)
				{
					routes.Add(null);
				}
				routes.Add(new List<Route>(Enumerable.Repeat<Route>(null, cityDictionary.Count)));
			}
		}
		public MatrixDatabase(IEnumerable<Route> routes)
		{
            foreach (var route in routes)
			{
				AddCity(route.From);
				AddCity(route.To);
			}
			foreach (var route in routes)
			{
				this.routes[cityIds[route.From]][cityIds[route.To]] = route;
			}
		}

		public void AddRoute(City from, City to, double cost, double travelTime, VehicleType vehicle)
		{
			AddCity(from);
			AddCity(to);
			routes[cityIds[from]][cityIds[to]] = new Route { From = from, To = to, Cost = cost, TravelTime = travelTime, VehicleType = vehicle };
		}

		public IDataIRoutesIterator GetRoutesIterator(City from)
		{
			return new MatrixDatabaseRoutesIterator(cityIds, cityDictionary, routes, from.Name);
		}
		public List<Route> /* */ GetRoutesFrom(City from)
		{
			List<Route> outputList = new List<Route>();
			/*
			* Fill this fragment and return Type.
			* Modyfing existing code in this class is forbidden.
			* Adding new elements (fields, private classes) to this class is allowed.
			*/

			IDataIRoutesIterator routesIterator = GetRoutesIterator(from);
			while(routesIterator.TryNextRoute())
			{
				outputList.Add(routesIterator.GetCurrentRoute());
			}
			return outputList;
		}
		public City GetByName(string cityName)
		{
			return cityDictionary[cityName];
		}
	}
}
