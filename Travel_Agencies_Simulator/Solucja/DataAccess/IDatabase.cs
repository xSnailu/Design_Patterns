using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DatabaseIterators;

namespace TravelAgencies.DataAccess
{
    interface IDatabase<dataType>
    {
        IDatabaseIterator<dataType> GetIterator();
    }
}
