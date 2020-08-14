using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucja.TravelAgentsAbstractFactory
{
    public interface ITrip
    {
        void ShowContent();
    }

    class PolandTrip : ITrip
    {
        Day[] days;
        public PolandTrip(Day[] days)
        {
            this.days = new Day[days.Length];
            for (int i = 0; i < days.Length; i++)
                this.days[i] = days[i];
        }

        public void ShowContent()
        {
            Console.WriteLine("Rating: {0}", this.GetTripRating().ToString("F4"));
            Console.WriteLine("Price: {0}", this.GetTripPrice());
            Console.WriteLine();

            for(int i=0; i<days.Length; i++)
            {
                Console.WriteLine("Day {0} in Poland!", i + 1);
                Console.WriteLine("Accomodation: {0}", days[i].Accomodation.Name);
                Console.WriteLine("Attractions:");
                for(int j=0; j<days[i].Attractions.Length; j++)
                {
                    Console.Write("          ");
                    Console.WriteLine(days[i].Attractions[j].Names);
                }
                    

            }
        }
        public double GetTripRating()
        {
            double rating = 0;
            foreach (Day day in days)
                rating = rating + day.getDayRating();

            return rating / days.Length;
        }
        public double GetTripPrice()
        {
            double price = 0;
            foreach (Day day in days)
                price = price + day.getDayPrice();

            return price;
        }
    }
    class ItalyTrip : ITrip
    {
        Day[] days;
        public ItalyTrip(Day[] days)
        {
            this.days = new Day[days.Length];
            for (int i = 0; i < days.Length; i++)
                this.days[i] = days[i];
        }

        public void ShowContent()
        {
            Console.WriteLine("Rating: {0}", this.GetTripRating().ToString("F4"));
            Console.WriteLine("Price: {0}", this.GetTripPrice());
            Console.WriteLine();

            for (int i = 0; i < days.Length; i++)
            {
                Console.WriteLine("Day {0} in Italy!", i + 1);
                Console.WriteLine("Accomodation: {0}", days[i].Accomodation.Name);
                Console.WriteLine("Attractions:");
                for (int j = 0; j < days[i].Attractions.Length; j++)
                {
                    Console.Write("          ");
                    Console.WriteLine(days[i].Attractions[j].Names);
                }

            }
        }
        public double GetTripRating()
        {
            double rating = 0;
            foreach (Day day in days)
                rating = rating + day.getDayRating();

            return rating / days.Length;
        }
        public double GetTripPrice()
        {
            double price = 0;
            foreach (Day day in days)
                price = price + day.getDayPrice();

            return price;
        }
    }
    class FranceTrip : ITrip
    {
        Day[] days;
        public FranceTrip(Day[] days)
        {
            this.days = new Day[days.Length];
            for (int i = 0; i < days.Length; i++)
                this.days[i] = days[i];
        }

        public void ShowContent()
        {
            Console.WriteLine("Rating: {0}", this.GetTripRating().ToString("F4"));
            Console.WriteLine("Price: {0}", this.GetTripPrice());
            Console.WriteLine();

            for (int i = 0; i < days.Length; i++)
            {
                Console.WriteLine("Day {0} in France!", i + 1);
                Console.WriteLine("Accomodation: {0}", days[i].Accomodation.Name);
                Console.WriteLine("Attractions:");
                for (int j = 0; j < days[i].Attractions.Length; j++)
                {
                    Console.Write("          ");
                    Console.WriteLine(days[i].Attractions[j].Names);
                }

            }
        }
        public double GetTripRating()
        {
            double rating = 0;
            foreach (Day day in days)
                rating = rating + day.getDayRating();

            return rating / days.Length;
        }
        public double GetTripPrice()
        {
            double price = 0;
            foreach (Day day in days)
                price = price + day.getDayPrice();

            return price;
        }
    }
}
