using BigTask2.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.DataIterator
{
    class MatrixDatabaseRoutesIterator : IDataIRoutesIterator
    {
        private Dictionary<City, int> cityIds;
        private Dictionary<string, City> cityDictionary;
        private List<List<Route>> routes;
        private string cityName;
        private int curPos = 0;
        private Route curRoute = null;

        public MatrixDatabaseRoutesIterator(Dictionary<City, int> cityIds, Dictionary<string, City> cityDictionary, List<List<Route>> routes, string cityName)
        {
            this.cityIds = cityIds;
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
            if(curPos < routes[cityIds[cityDictionary[cityName]]].Count)
            {
                curRoute = routes[cityIds[cityDictionary[cityName]]][curPos];
                curPos += 1;
                if(curRoute == null)
                {
                    return TryNextRoute();
                }
                return true;
            }else
            {
                return false;
            }
        }
    }
}
