using System;
using Problems;

namespace Solvers
{
    abstract class NetworkDevice : ISolver
    {
        protected string DeviceType { get; set; } = "NetworkDevice";

        protected readonly string model;
        private int dataLimit;

        protected NetworkDevice(string model, int dataLimit)
        {
            this.model = model;
            this.dataLimit = dataLimit;
        }

        protected bool DecreaseDataLimitIfDataLimitIsEnoughToTransferData(int data)
        {
            if(dataLimit>=data)
            {
                dataLimit -= data;
                return true;
            }
            else
            {
                return false;
            }
        }

        //abstract solver that wifi and ethernet must override
        abstract public bool trySolve(CompositeProblem problem);


        abstract public bool trySolve(CPUProblem problem);


        abstract public bool trySolve(GPUProblem problem);


        abstract public bool trySolve(NetworkProblem problem);
        
    }
}