using System;

namespace PictureProduction
{
    class MachinePainterOnlyRed : IMachine
    {
        IMachine nextmachine;
        public string MachineType
        {
            get { return "paint"; }
        }
        public IMachine nextMachine
        {
            get { return nextmachine; }   
            set { nextmachine = value; }  
        }

        public void Handle(Order order, IPicture picture)
        {
            if (order.Color != "red")
            {
                if (nextMachine != null)
                {
                    if (nextmachine.MachineType == "paint" || nextmachine.MachineType == "write")
                    {
                        nextMachine.Handle(order, new PaintPictureDecorator(picture, ""));
                        return;
                    }

                }
            }
            else if (order.Color == "red")
            {

                if (nextMachine != null)
                {
                    if (nextmachine.MachineType == "paint" || nextmachine.MachineType == "write")
                    {
                        nextMachine.Handle(order, new PaintPictureDecorator(picture, "red"));
                        return;
                    }

                }
            }
        }

        public void set_next(IMachine machine)
        {
            nextMachine = machine;
        }
    }

    class MachineWriterNoTextOperationsSupported : IMachine
    {
        IMachine nextmachine;
        public string MachineType
        {
            get { return "write"; }
        }
        public IMachine nextMachine
        {
            get { return nextmachine; }   
            set { nextmachine = value; }  
        }

        public void Handle(Order order, IPicture picture)
        {
            if (nextMachine != null)
            {
                if (nextmachine.MachineType == "write" || nextmachine.MachineType == "shape")
                {
                    nextMachine.Handle(order, new WriteOnPictureDecorator(picture, order.Text));
                    return;
                }

            }
            Console.WriteLine("Error: Invalid order!");
            return;
        }

        public void set_next(IMachine machine)
        {
            nextMachine = machine;
        }
    }

    class MachineShaperOnlyCircleAndSquareSupported : IMachine
    {
        IMachine nextmachine;
        public string MachineType
        {
            get { return "shape"; }
        }
        public IMachine nextMachine
        {
            get { return nextmachine; }   
            set { nextmachine = value; }  
        }

        public void Handle(Order order, IPicture picture)
        {
            if (order.Shape == "circle" || order.Shape == "square")
            {
                if (nextMachine != null)
                {
                    if(nextmachine.MachineType == "shape" || nextmachine.MachineType == "frame")
                    {
                        nextMachine.Handle(order, picture);
                        return;
                    }
                    
                }
                Console.WriteLine("Error: Invalid order!");
                return;
            }
            else
            {
                Console.WriteLine("Error: Cannot create picture!");
                return;
            }
        }

        public void set_next(IMachine machine)
        {
            nextMachine = machine;
        }
    }

    class MachineFramerFrameLengthEqualTwo : IMachine
    {
        IMachine nextmachine;
        public string MachineType
        {
            get { return "frame"; }
        }
        public IMachine nextMachine
        {
            get { return nextmachine; }   
            set { nextmachine = value; }  
        }

        public void Handle(Order order, IPicture picture)
        {
            string leftframe = String.Empty;
            string rightframe = String.Empty;

            switch (order.Shape)
            {
                case "circle":
                    leftframe = "((";
                    rightframe = "))";
                    break;
                case "square":
                    leftframe = "[[";
                    rightframe = "]]";
                    break;
            }

            

            if (nextMachine != null)
            {
                if (nextmachine.MachineType == "frame" || nextmachine.MachineType == "last")
                {
                    nextMachine.Handle(order, new FramePictureDecorator(picture, leftframe, rightframe));
                    return;
                }

            }
            Console.WriteLine("Error: Invalid order!");
            return;


        }

        public void set_next(IMachine machine)
        {
            nextMachine = machine;
        }
    }

}