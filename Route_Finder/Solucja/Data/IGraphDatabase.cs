//This file contains fragments that You have to fulfill

using BigTask2.Api;
using System.Collections.Generic;

namespace BigTask2.Data
{
    public interface IGraphDatabase
    {
        //Fill the return type of the method below
        /* */ List<Route> GetRoutesFrom(City from);
        City GetByName(string cityName);
    }
}
