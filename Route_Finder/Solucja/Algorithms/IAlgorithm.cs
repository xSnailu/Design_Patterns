using BigTask2.Api;
using BigTask2.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.Algorithms
{
    interface IAlgorithm
    {
        IEnumerable<Route> Solve(IGraphDatabase graph, City from, City to);
    }
}
