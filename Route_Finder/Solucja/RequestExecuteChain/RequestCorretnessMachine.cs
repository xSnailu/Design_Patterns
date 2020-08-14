using BigTask2.Algorithms;
using BigTask2.AlhorithmExecuteChain;
using BigTask2.Api;
using BigTask2.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.RequestAnalyseChain
{
    class RequestCorretnessMachine : IRequestChainNode
    {
        IRequestChainNode nextNode;
        IRequestChainNode defaultNode = new DefaultRequestMachine();
        public bool IsRequestCorreect(Request rq)
        {
            if (rq.To == null || rq.From == null)
                return false;
            if (rq.Filter.MinPopulation < 0)
                return false;
            if (rq.Filter.AllowedVehicles.Count <= 0)
                return false;

            return true;
        }

        public IEnumerable<Route> Handle(Request rq, IGraphDatabase db1, IGraphDatabase db2 = null, IAlgorithm algorithm = null)
        {
            if(IsRequestCorreect(rq))
            {
                return nextNode.Handle(rq, db1, db2, algorithm);
            }
            else
            {
                Console.WriteLine("Error inncorect request data!");
                return defaultNode.Handle(rq, db1, db2, algorithm);
            }

        }

        public void SetNext(IRequestChainNode nextChainNode)
        {
            nextNode = nextChainNode;
        }
    }
}
