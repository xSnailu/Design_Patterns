using System;
using Problems;

namespace Solvers
{
    class Ethernet : NetworkDevice
    {
        
        public Ethernet(string model, int dataLimit) : base(model, dataLimit)
        {
            DeviceType = "Ethernet";
            
        }

        public override bool trySolve(CompositeProblem problem)
        {
            Console.WriteLine("{1} didn't solve problem. {2}", this.GetType().ToString(), this.model, problem.Name); return false;
        }

        public override bool trySolve(CPUProblem problem)
        {
            Console.WriteLine("{1} didn't solve problem. {2}", this.GetType().ToString(), this.model, problem.Name); return false;
        }

        public override bool trySolve(GPUProblem problem)
        {
            Console.WriteLine("{1} didn't solve problem. {2}", this.GetType().ToString(), this.model, problem.Name); return false;
        }

        public override bool trySolve(NetworkProblem problem)
        {
            if (this.DecreaseDataLimitIfDataLimitIsEnoughToTransferData(problem.DataToTransfer))
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
    }
}