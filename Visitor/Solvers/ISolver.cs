using Problems;

namespace Solvers
{
    interface ISolver
    {
        public bool trySolve(CompositeProblem problem);
        public bool trySolve(CPUProblem problem);
        public bool trySolve(GPUProblem problem);
        public bool trySolve(NetworkProblem problem);
    }
}