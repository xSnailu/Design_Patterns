using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Codec;

namespace TravelAgencies.CodecMachine
{
    interface ICodecMachine
    {
        void SetNext(ICodecMachine nextCodecMachine);
        string Handle(string inputString);
    }

    class FrameCodecMachine : ICodecMachine
    {
        private ICodecMachine nextCodecMachine = null;
        private ICodecMachine lastCodecMachine = new LastCodecMachine();
        private int n;
        public FrameCodecMachine(int n)
        {
            this.n = n;  
        }
        public void SetNext(ICodecMachine nextCodecMachine)
        {
            this.nextCodecMachine = nextCodecMachine;
        }

        public string Handle(string inputString)
        {
            if(nextCodecMachine!=null)
            {
                FrameCodec frameCodec = new FrameCodec(n);
                return nextCodecMachine.Handle(frameCodec.FrameCodecWork(inputString));
            }
            else
            {
                FrameCodec frameCodec = new FrameCodec(n);
                return lastCodecMachine.Handle(frameCodec.FrameCodecWork(inputString));
            }
        }
    }

    class ReverseCodecMachine : ICodecMachine
    {
        private ICodecMachine nextCodecMachine = null;
        private ICodecMachine lastCodecMachine = new LastCodecMachine();
        
        public ReverseCodecMachine() {}
        public void SetNext(ICodecMachine nextCodecMachine)
        {
            this.nextCodecMachine = nextCodecMachine;
        }

        public string Handle(string inputString)
        {
            if (nextCodecMachine != null)
            {
                ReverseCodec reverseCodec = new ReverseCodec();
                return nextCodecMachine.Handle(reverseCodec.ReverseCodecWork(inputString));
            }
            else
            {
                return lastCodecMachine.Handle(inputString);
            }
        }
    }

    class PushCodecMachine : ICodecMachine
    {
        private ICodecMachine nextCodecMachine = null;
        private ICodecMachine lastCodecMachine = new LastCodecMachine();
        private int n;
        public PushCodecMachine(int n)
        {
            this.n = n;
        }
        public void SetNext(ICodecMachine nextCodecMachine)
        {
            this.nextCodecMachine = nextCodecMachine;
        }

        public string Handle(string inputString)
        {
            if (nextCodecMachine != null)
            {
                PushCodec pushCodec = new PushCodec(n);
                return nextCodecMachine.Handle(pushCodec.PushCodecWork(inputString));
            }
            else
            {
                PushCodec pushCodec = new PushCodec(n);
                return lastCodecMachine.Handle(pushCodec.PushCodecWork(inputString));
            }
        }
    }

    class CezarCodecMachine : ICodecMachine
    {
        private ICodecMachine nextCodecMachine = null;
        private ICodecMachine lastCodecMachine = new LastCodecMachine();
        private int n;
        public CezarCodecMachine(int n)
        {
            this.n = n;
        }
        public void SetNext(ICodecMachine nextCodecMachine)
        {
            this.nextCodecMachine = nextCodecMachine;
        }

        public string Handle(string inputString)
        {
            if (nextCodecMachine != null)
            {
                CezarCodec cezarCodec = new CezarCodec(n);
                return nextCodecMachine.Handle(cezarCodec.CezarCodecWork(inputString));
            }
            else
            {
                CezarCodec cezarCodec = new CezarCodec(n);
                return lastCodecMachine.Handle(cezarCodec.CezarCodecWork(inputString));
            }
        }
    }

    class SwapCodecMachine : ICodecMachine
    {
        private ICodecMachine nextCodecMachine = null;
        private ICodecMachine lastCodecMachine = new LastCodecMachine();

        public SwapCodecMachine() { }
        public void SetNext(ICodecMachine nextCodecMachine)
        {
            this.nextCodecMachine = nextCodecMachine;
        }

        public string Handle(string inputString)
        {
            if (nextCodecMachine != null)
            {
                SwapCodec swapCodec = new SwapCodec();
                return nextCodecMachine.Handle(swapCodec.SwapCodecWork(inputString));
            }
            else
            {
                SwapCodec swapCodec = new SwapCodec();
                return lastCodecMachine.Handle(swapCodec.SwapCodecWork(inputString));
            }
        }
    }

    class LastCodecMachine : ICodecMachine
    {
        public void SetNext(ICodecMachine nextCodecMachine)
        {
            throw new NotImplementedException();
        }

        public string Handle(string inputString)
        {
            return inputString;
        }
    }
}
