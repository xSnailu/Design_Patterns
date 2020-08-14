using System;
using Problems;

namespace Solvers
{
    class GPU : ISolver
    {
        static private int MaxTemperature { get; } = 100;
        static private int CPUProblemTemperatureMultiplier { get; } = 3;

        private readonly string model;
        private int temperature;
        private int coolingFactor;

        public GPU(string model, int temperature, int coolingFactor)
        {
            this.model = model;
            this.temperature = temperature;
            this.coolingFactor = coolingFactor;
        }
        private bool DidThermalThrottle()
        {
            if (temperature > MaxTemperature)
            {
                Console.WriteLine($"GPU {model} thermal throttled");
                CoolDown();
                return true;
            }

            return false;
        }

        private void CoolDown()
        {
            temperature -= coolingFactor;
        }

        public bool trySolve(CompositeProblem problem)
        {
            Console.WriteLine("{1} didn't solve problem. {2}", this.GetType().ToString(), this.model, problem.Name); return false;
        }

        public bool trySolve(CPUProblem problem)
        {
            this.temperature += problem.RequiredThreads * CPUProblemTemperatureMultiplier;
            Console.WriteLine("{1} solved problem. {2}", this.GetType().ToString(), this.model, problem.Name);
            return true;
        }

        public bool trySolve(GPUProblem problem)
        {
            if(!DidThermalThrottle())
            {
                this.temperature += problem.GpuTemperatureIncrease;
                Console.WriteLine("{1} solved problem. {2}", this.GetType().ToString(), this.model, problem.Name);
                return true;
            }
            else
            {           
                CoolDown();
                Console.WriteLine("{1} didn't solve problem. {2}", this.GetType().ToString(), this.model, problem.Name); return false;
            }
        }

        public bool trySolve(NetworkProblem problem)
        {
            Console.WriteLine("{1} didn't solve problem. {2}", this.GetType().ToString(), this.model, problem.Name); return false;
        }
    }
}