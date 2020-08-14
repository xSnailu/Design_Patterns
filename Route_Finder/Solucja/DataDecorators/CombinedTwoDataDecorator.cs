using BigTask2.Api;
using BigTask2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigTask2.DataDecorators
{
    class CombinedTwoDataDecorator : IGraphDatabase
    {
        private IGraphDatabase firstDB;
        private IGraphDatabase secondDB;

        public CombinedTwoDataDecorator(IGraphDatabase firstDB, IGraphDatabase secondDB)
        {
            this.firstDB = firstDB;
            this.secondDB = secondDB;
        }

        public City GetByName(string cityName)
        {
            try
            {
                return firstDB.GetByName(cityName);
            }
            catch (KeyNotFoundException)
            {
                return secondDB.GetByName(cityName);
            }     
        }

        public List<Route> GetRoutesFrom(City from)
        {
            List<Route> firstList = new List<Route>();
            List<Route> secondList = new List<Route>();

            try
            {
                firstList = firstDB.GetRoutesFrom(from);
            }
            catch (KeyNotFoundException)
            {
                return secondDB.GetRoutesFrom(from);
            }

            try
            {
                secondList = secondDB.GetRoutesFrom(from);
            }
            catch (KeyNotFoundException)
            {
                firstDB.GetRoutesFrom(from);
            }
            
            return firstList.Concat(secondList).ToList();

        }
    }
}
