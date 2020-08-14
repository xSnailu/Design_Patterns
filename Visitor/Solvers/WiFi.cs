using System;
using Problems;

namespace Solvers
{
    class WiFi : NetworkDevice
    {
        private readonly double packetLossChance;
        private static readonly Random rng = new Random(1597);

        public WiFi(string model, int dataLimit, double packetLossChance) : base(model, dataLimit)
        {
            DeviceType = "WiFi";
            this.packetLossChance = packetLossChance;
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
                if (rng.NextDouble() < packetLossChance)
                {
                    Console.WriteLine("{1} didn't solve problem. {2}", this.GetType().ToString(), this.model, problem.Name);
                    return false;
                }
                else
                {
                    Console.WriteLine("{1} solved problem. {2}", this.GetType().ToString(), this.model, problem.Name);
                    return true;
                }
            else
            {
                return false;
            }
        }
    }
}