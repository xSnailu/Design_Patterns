using BigTask2.Algorithms;
using BigTask2.AlhorithmExecuteChain;
using BigTask2.Api;
using BigTask2.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.RequestAnalyseChain
{
    class RequestAlgorithmDetectionMachine : IRequestChainNode
    {
        private IRequestChainNode nextNode;
        private IRequestChainNode defaultNode = new DefaultRequestMachine();

        public IEnumerable<Route> Handle(Request rq, IGraphDatabase db1, IGraphDatabase db2 = null, IAlgorithm algorithm = null)
        {
            return nextNode.Handle(rq, db1 , db2, DetectAlgoritm(rq));
        }

        private IAlgorithm DetectAlgoritm(Request rq)
        {
            if (rq.Solver == "BFS")
                return new BFS();
            if (rq.Solver == "DFS")
                return new DFS();
            if (rq.Solver == "Dijkstra" && rq.Problem == "Time")
                return new DijkstraTime();
            if (rq.Solver == "Dijkstra" && rq.Problem == "Cost")
                return new DijkstraCost();
 
            return null;
        }

        public void SetNext(IRequestChainNode nextChainNode)
        {
            nextNode = nextChainNode;
        }
    }
}
