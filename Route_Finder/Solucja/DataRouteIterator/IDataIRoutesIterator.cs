using BigTask2.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.DataIterator
{
    interface IDataIRoutesIterator
    {
        Route GetCurrentRoute();
        bool TryNextRoute();
    }
}
