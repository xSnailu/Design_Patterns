using BigTask2.Algorithms;
using BigTask2.AlhorithmExecuteChain;
using BigTask2.Api;
using BigTask2.Data;
using BigTask2.DataDecorators;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.AlhorithmExecuteChain
{
    class MergeTwoDatabasesRequestmMachine : IRequestChainNode
    {
        private IRequestChainNode nextNode;
        private IRequestChainNode DefaultAlgorithmMachine = new DefaultRequestMachine();

        public IEnumerable<Route> Handle(Request rq, IGraphDatabase db1, IGraphDatabase db2 = null, IAlgorithm algorithm = null)
        {
            if(db2!=null)
            {
                IGraphDatabase mergedDatabase = new CombinedTwoDataDecorator(db1, db2);
                return nextNode.Handle(rq, mergedDatabase, null, algorithm);
            }
            else
            {
                return nextNode.Handle(rq, db1, null, algorithm);
            }    
        }

        public void SetNext(IRequestChainNode nextAlgorithmNode)
        {
            nextNode = nextAlgorithmNode;
        }
    }
}
