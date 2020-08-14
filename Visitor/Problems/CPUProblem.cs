using System;
using Solvers;

namespace Problems
{
    class CPUProblem : Problem
    {
        public int RequiredThreads { get; }

        public CPUProblem(string name, Func<int> computation, int requiredThreads) : base(name, computation)
        {
            RequiredThreads = requiredThreads;
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