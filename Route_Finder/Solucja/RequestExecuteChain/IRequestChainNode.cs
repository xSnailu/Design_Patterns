using BigTask2.Algorithms;
using BigTask2.Api;
using BigTask2.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.AlhorithmExecuteChain
{
    interface IRequestChainNode
    {
        void SetNext(IRequestChainNode nextAlgorithmNode);
        IEnumerable<Route> Handle(Request rq, IGraphDatabase db1, IGraphDatabase db2 = null, IAlgorithm algorithm = null);
    }
}
