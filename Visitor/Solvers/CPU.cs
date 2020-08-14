using System;
using Problems;

namespace Solvers
{
    class CPU : ISolver
    {
        private readonly string model;
        private readonly int threads;

        public CPU(string model, int threads)
        {
            this.model = model;
            this.threads = threads;
        }

        public bool trySolve(CompositeProblem problem)
        {
            return problem.tryBeSolved(this);
        }

        public bool trySolve(CPUProblem problem)
        {
            if (this.threads >= problem.RequiredThreads)
            {
                Console.WriteLine("{1} solved problem. {2}", this.GetType().ToString(), this.model, problem.Name);
                return true;
            }
            else
            {
                Console.WriteLine("{1} didn't solve problem. {2}", this.GetType().ToString(), this.model, problem.Name);
                return false;
            }        
        }

        public bool trySolve(GPUProblem problem)
        {
            Console.WriteLine("{1} didn't solve problem. {2}", this.GetType().ToString(), this.model, problem.Name);
            return false;
        }

        public bool trySolve(NetworkProblem problem)
        {
            Console.WriteLine("{1} didn't solve problem. {2}", this.GetType().ToString(), this.model, problem.Name);
            return false;
        }
    }
}