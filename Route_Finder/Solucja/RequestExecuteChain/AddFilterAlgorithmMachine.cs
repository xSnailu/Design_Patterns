using BigTask2.Algorithms;
using BigTask2.Api;
using BigTask2.Data;
using BigTask2.DataDecorators;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.AlhorithmExecuteChain
{
    class AddFilterAlgorithmMachine : IRequestChainNode
    {
        private IRequestChainNode nextNode;
        private IRequestChainNode DefaultAlgorithmMachine = new DefaultRequestMachine();

        public IEnumerable<Route> Handle(Request rq, IGraphDatabase db1, IGraphDatabase db2 = null, IAlgorithm algorithm = null)
        {
            IGraphDatabase filteredDatabase = new FilterDataDecorator(db1, rq.Filter);
            return nextNode.Handle(rq, filteredDatabase, null, algorithm);
        }

        public void SetNext(IRequestChainNode nextAlgorithmNode)
        {
            nextNode = nextAlgorithmNode;
        }
    }
}
