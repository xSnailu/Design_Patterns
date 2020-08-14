using System;

namespace PictureProduction
{
    class MachinePainterRGB : IMachine
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
            string color;
            switch (order.Color)
            {
                case "red":
                    color = "red";
                    break;
                case "blue":
                    color = "blue";
                    break;
                case "green":
                    color = "green";
                    break;
                default:
                    color = "";
                    break;
            }

            if (nextMachine != null)
            {
                if (nextmachine.MachineType == "paint" || nextmachine.MachineType == "write")
                {
                    nextMachine.Handle(order, new PaintPictureDecorator(picture, color));
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






    class MachineWriterSpacingAndUppercaseTextOpperations : IMachine
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
            string outputtext = String.Empty;
            switch (order.Operation)
            {
                case "spacing":
                    for (int i = 0; i < order.Text.Length; i++)
                    {
                        outputtext += order.Text[i];
                        outputtext += " ";
                    }
                    break;
                case "uppercase":
                    outputtext = order.Text.ToUpper();
                    break;
                default:
                    outputtext = order.Text;
                    break;
            }


            if (nextMachine != null)
            {
                if (nextmachine.MachineType == "write" || nextmachine.MachineType == "shape")
                {
                    nextMachine.Handle(order, new WriteOnPictureDecorator(picture, outputtext));
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



    class MachineShaperOnlyCircleSquareAndTriangleSupported : IMachine
    {
        IMachine nextmachine;
        public string MachineType
        {
            get { return "shape"; }
        }
        public IMachine nextMachine
        {
            get { return nextmachine; }   // get method
            set { nextmachine = value; }  // set method
        }

        public void Handle(Order order, IPicture picture)
        {
            if (order.Shape == "circle" || order.Shape == "square" || order.Shape == "triangle")
            {
                if (nextMachine != null)
                {
                    if (nextmachine.MachineType == "shape" || nextmachine.MachineType == "frame")
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



    class MachineFramerFrameLengthDependsOnPreviousOperations : IMachine
    {
        IMachine nextmachine;
        public string MachineType
        {
            get { return "frame"; }
        }
        public IMachine nextMachine
        {
            get { return nextmachine; }   // get method
            set { nextmachine = value; }  // set method
        }

        string leftframe;
        string rightframe;

        public void Handle(Order order, IPicture picture)
        {

            switch (order.Shape)
            {
                case "circle":
                    leftframe = "(";
                    rightframe = ")";
                    break;
                case "square":
                    leftframe = "[";
                    rightframe = "]";
                    break;
                case "triangle":
                    leftframe = "<";
                    rightframe = ">";
                    break;
            }

            int size;
            if (picture.Color == "" && order.Operation == "spacing")
                {
                    size = 3;
                }
            else if (picture.Color == "")
                {
                    size = 2;
                }
            else if (order.Operation == "spacing")
                {
                    size = 2;
                }
            else
                {
                    size = 1;
                }

            string outputleftframe = String.Empty;
            string outputrightframe = String.Empty;
            for (int i = 0; i < size; i++)
            {
                outputleftframe += leftframe;
                outputrightframe += rightframe;
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