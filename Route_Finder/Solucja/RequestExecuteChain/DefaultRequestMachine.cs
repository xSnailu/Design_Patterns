using BigTask2.Algorithms;
using BigTask2.Api;
using BigTask2.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.AlhorithmExecuteChain
{
    class DefaultRequestMachine : IRequestChainNode
    {
        public IEnumerable<Route> Handle(Request rq,  IGraphDatabase db1, IGraphDatabase db2 = null, IAlgorithm algorithm = null)
        {
            return new List<Route>();
        }

        public void SetNext(IRequestChainNode nextAlgorithmNode)
        {
            throw new NotImplementedException();
        }
    }
}
