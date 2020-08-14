using BigTask2.Api;
using BigTask2.DataIterator;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.DataRouteIterator
{
    class AdjacencyListDatabaseRoutesIterator : IDataIRoutesIterator
    {
        private Dictionary<string, City> cityDictionary;
        private Dictionary<City, List<Route>> routes;
        private int curpos = 0;
        private Route curRoute = null;
        private string cityName;

        public AdjacencyListDatabaseRoutesIterator(Dictionary<string, City> cityDictionary, Dictionary<City, List<Route>> routes, string cityName)
        {
            this.cityDictionary = cityDictionary;
            this.routes = routes;
            this.cityName = cityName;
        }

        public Route GetCurrentRoute()
        {
            return curRoute;
        }

        public bool TryNextRoute()
        {
         if( curpos < routes[cityDictionary[cityName]].Count)
            {
                curRoute = routes[cityDictionary[cityName]][curpos];
                curpos += 1;
                if (curRoute == null)
                {
                    return TryNextRoute();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
