using BigTask2.Algorithms;
using BigTask2.AlhorithmExecuteChain;
using BigTask2.Api;
using BigTask2.Data;
using BigTask2.RequestAnalyseChain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.AlgorithmExecuteChain
{
    static class RequestExecuteChainClass
    {
        public static IEnumerable<Route> ExecuteRequest(Request rq, IGraphDatabase db1, IGraphDatabase db2 = null, IAlgorithm algorithm = null)
        {

            IRequestChainNode firstmachine = new RequestCorretnessMachine();
            IRequestChainNode secondmachine = new RequestAlgorithmDetectionMachine();
            IRequestChainNode thirdmachine = new MergeTwoDatabasesRequestmMachine();
            IRequestChainNode fourthmachine = new AddFilterAlgorithmMachine();
            IRequestChainNode fifthmachine = new ExecuteAlgorithmMachine();

            firstmachine.SetNext(secondmachine);
            secondmachine.SetNext(thirdmachine);
            thirdmachine.SetNext(fourthmachine);
            fourthmachine.SetNext(fifthmachine);


            IEnumerable<Route> outputRoute = firstmachine.Handle(rq, db1, db2, algorithm);
            return outputRoute;
        }
    }
}
