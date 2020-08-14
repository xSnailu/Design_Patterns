using System;
using System.Collections.Generic;

namespace PictureProduction
{
    class Program
    {
        private readonly static Order[] orders =
        {
            new Order("circle", "red", "Hello", "spacing"),
            new Order("square", "green", "HelloWorld", "spacing"),
            new Order("triangle", "blue", "ChainIsBeauty", "spacing"),

            new Order("circle", "red", "Hello", "uppercase"),
            new Order("square", "green", "HelloWorld", "uppercase"),
            new Order("triangle", "blue", "ChainIsBeauty", "uppercase"),

            new Order("circle", "red", "Hello", "lowercase"),
            new Order("square", "yellow", "HelloWorld", "lowercase"),
            new Order("hash", "red", "ChainIsBeauty", "uppercase"),

            new Order("", "green", "ChainIsBeauty", "uppercase"), //invalid order
            new Order("star", "1234", "ChainIsBeauty", "uppercase"), //invalid order
            new Order("star", "green", null, "uppercase"), //invalid order
        };

        private static IMachine ProductLineConstructor(IMachine MachinePainter, IMachine MachineWriter, IMachine MachineShaper, IMachine MachineFramer)
        {
            IMachine ProductLine = new MachineFirstMachine();
            ProductLine.set_next(MachinePainter);
            MachinePainter.set_next(MachineWriter);
            MachineWriter.set_next(MachineShaper);
            MachineShaper.set_next(MachineFramer);
            MachineFramer.set_next(new MachineLastMachine());

            return ProductLine;
        }


        static void ProducePictures(IEnumerable<Order> orders, IMachine productline)
        {
            foreach (Order order in orders)
            {
                EmptyPicture output = new EmptyPicture();
                productline.Handle(order, output);
            }
        }

 

        static void Main(string[] args)
        {
            Console.WriteLine("--- Simple Production Line ---");
            IMachine productLine1 = ProductLineConstructor(new MachinePainterOnlyRed(), new MachineWriterNoTextOperationsSupported(), new MachineShaperOnlyCircleAndSquareSupported(), new MachineFramerFrameLengthEqualTwo());
            ProducePictures(orders, productLine1);

            Console.WriteLine();

            Console.WriteLine("--- Complex Production Line ---");
            IMachine productLine2 = ProductLineConstructor(new MachinePainterRGB(), new MachineWriterSpacingAndUppercaseTextOpperations(), new MachineShaperOnlyCircleSquareAndTriangleSupported(), new MachineFramerFrameLengthDependsOnPreviousOperations());
            ProducePictures(orders, productLine2);
        }
    }
}
