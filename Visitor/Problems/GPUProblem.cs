using System;
using Solvers;

namespace Problems
{
    class GPUProblem : Problem
    {
        public int GpuTemperatureIncrease { get; }

        public GPUProblem(string name, Func<int> computation, int gpuTemperatureIncrease) : base(name, computation)
        {
            GpuTemperatureIncrease = gpuTemperatureIncrease;
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