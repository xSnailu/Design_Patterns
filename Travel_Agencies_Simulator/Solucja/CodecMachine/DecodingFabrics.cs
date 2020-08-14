using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.CodecMachine
{
    static class BookingDatabaseDecoder
    {
        public static string Decode(string input)
        {
            ICodecMachine decodingMachine1 = new SwapCodecMachine();
            ICodecMachine decodingMachine2 = new CezarCodecMachine(1);
            ICodecMachine decodingMachine3 = new ReverseCodecMachine();
            ICodecMachine decodingMachine4 = new FrameCodecMachine(-2);

            decodingMachine1.SetNext(decodingMachine2);
            decodingMachine2.SetNext(decodingMachine3);
            decodingMachine3.SetNext(decodingMachine4);

            return decodingMachine1.Handle(input);
        }
    }

    static class ShutterStockDecoder
    {
        public static string Decode(string input)
        {
            ICodecMachine decodingMachine1 = new ReverseCodecMachine();
            ICodecMachine decodingMachine2 = new PushCodecMachine(3);
            ICodecMachine decodingMachine3 = new FrameCodecMachine(-1);
            ICodecMachine decodingMachine4 = new CezarCodecMachine(-4);



            decodingMachine1.SetNext(decodingMachine2);
            decodingMachine2.SetNext(decodingMachine3);
            decodingMachine3.SetNext(decodingMachine4);

            return decodingMachine1.Handle(input);
        }
    }

    static class TripAdvisorDecoder
    {
        public static string Decode(string input)
        {
            ICodecMachine decodingMachine1 = new PushCodecMachine(-3);
            ICodecMachine decodingMachine2 = new SwapCodecMachine();
            ICodecMachine decodingMachine3 = new FrameCodecMachine(-2);
            ICodecMachine decodingMachine4 = new PushCodecMachine(-3);


            decodingMachine1.SetNext(decodingMachine2);
            decodingMachine2.SetNext(decodingMachine3);
            decodingMachine3.SetNext(decodingMachine4);

            return decodingMachine1.Handle(input);
        }
    }

    static class OysterDatabaseDecoder
    {
        public static string Decode(string input)
        {
            return input;
        }
    }

}
