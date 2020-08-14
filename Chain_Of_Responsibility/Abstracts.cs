using System;

namespace PictureProduction
{
    public interface IMachine
    {
        // you can add required methods here
        IMachine nextMachine { get; set; }
        string MachineType { get; }

        void set_next(IMachine machine);
        void Handle(Order order, IPicture picture);
    }

    

    class MachineLastMachine : IMachine
    {
        IMachine nextmachine;
        public string MachineType
        {
            get { return "last"; }
        }
        public IMachine nextMachine
        {
            get { return nextmachine; }   
            set { nextmachine = value; }  
        }

        public void Handle(Order order, IPicture picture)
        {
            if(nextmachine != null)
            {
                Console.WriteLine("Error: Invalid order!");
                return;
            }

            picture.Print();
            return;
        }

        public void set_next(IMachine machine)
        {
            Console.WriteLine("{0} can't add next machine!", this.GetType());
        }
    }

    class MachineFirstMachine : IMachine
    {
        IMachine nextmachine;
        public string MachineType
        {
            get { return "first"; }
        }
        public IMachine nextMachine
        {
            get { return nextmachine; }   
            set { nextmachine = value; }  
        }

        public void Handle(Order order, IPicture picture)
        {
            if (order.Color == null
                || order.Operation == null
                || order.Shape == null
                || order.Text == null)
            {
                Console.WriteLine("Error: Invalid order!");
                return;
            }
            else
            {
                if (nextMachine != null && nextmachine.MachineType == "paint")
                {
                    nextMachine.Handle(order, picture);
                    return;
                }
                else
                {
                    Console.WriteLine("Error: Invalid order!");
                    return;
                }

            }
        }

        public void set_next(IMachine machine)
        {
            nextMachine = machine;
        }
    }




}
