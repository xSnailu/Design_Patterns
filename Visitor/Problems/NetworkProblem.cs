using System;
using Solvers;

namespace Problems
{
    class NetworkProblem : Problem
    {
        public int DataToTransfer { get; }

        public NetworkProblem(string name, Func<int> computation, int dataToTransfer) : base(name, computation)
        {
            DataToTransfer = dataToTransfer;
        }

        public override bool tryBeSolved(ISolver problemSolver)
        {

            if (this.Solved == true)
            {
                Console.WriteLine("Problem {0} already has been solved.", this.Name);
                return true;
            }

            if (problemSolver.trySolve(this))
            {
                this.TryMarkAsSolved(this.Computation());
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}