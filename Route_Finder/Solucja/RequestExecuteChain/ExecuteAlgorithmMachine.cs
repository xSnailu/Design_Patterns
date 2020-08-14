using BigTask2.Algorithms;
using BigTask2.Api;
using BigTask2.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.AlhorithmExecuteChain
{
    class ExecuteAlgorithmMachine : IRequestChainNode
    {
        private IRequestChainNode nextNode;
        private IRequestChainNode DefaultRequestMachine = new DefaultRequestMachine();

        public IEnumerable<Route> Handle(Request rq,IGraphDatabase db1, IGraphDatabase db2 = null, IAlgorithm algorithm = null)
        {
            if (algorithm == null)
                return DefaultRequestMachine.Handle(rq, db1, null, null);

            return algorithm.Solve(db1, db1.GetByName(rq.From), db1.GetByName(rq.To));
        }

        public void SetNext(IRequestChainNode nextAlgorithmNode)
        {
            throw new NotImplementedException();
        }
    }
}
