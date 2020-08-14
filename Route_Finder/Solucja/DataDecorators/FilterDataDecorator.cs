using BigTask2.Api;
using BigTask2.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.DataDecorators
{
    class FilterDataDecorator : IGraphDatabase
    {
        private IGraphDatabase database;
        private Filter dbFilter;

        public FilterDataDecorator(IGraphDatabase database, Filter dbFilter)
        {
            this.database = database;
            this.dbFilter = dbFilter;
        }

        public City GetByName(string cityName)
        {
            try
            {
                return database.GetByName(cityName);
            }
            catch(KeyNotFoundException)
            {
                return default(City);
            }     
        }

        private void ApplyFilterOnRouteList(List<Route> list)
        {
            //VEHICLE FILTER
            for(int i=0; i<list.Count; i++)
            {
                if (!dbFilter.AllowedVehicles.Contains(list[i].VehicleType))
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            //POPULATION FILTER
            for(int i=0; i<list.Count; i++)
            {
                if (list[i].To.Population < dbFilter.MinPopulation)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            //RESTAURANT FILTER
            if(dbFilter.RestaurantRequired)
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].To.HasRestaurant != dbFilter.RestaurantRequired)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        public List<Route> GetRoutesFrom(City from)
        {
            List<Route> outputList = new List<Route>();
            try
            {
                outputList = database.GetRoutesFrom(from);
            }
            catch (KeyNotFoundException)
            {
                return new List<Route>();
            }
            ApplyFilterOnRouteList(outputList);
            return outputList;
        }
    }
}
