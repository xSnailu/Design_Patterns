using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.CodecMachine;
using TravelAgencies.DataAccess;

namespace Solucja.TravelAgentsAbstractFactory
{
    class Day
    {
        public TripEncrypted[] Attractions;
        public ListNode Accomodation;
        int atractionPos;

        public Day()
        {
            Attractions = new TripEncrypted[3];
            atractionPos = 0;

        }
        public void AddAtraction(TripEncrypted attraction)
        {
            if (atractionPos == 3)
                return;
            Attractions[atractionPos] = attraction;
            atractionPos++;        
        }
        public void AddAccomodation(ListNode accomodation)
        {
            Accomodation = accomodation;
        }

        public int getDayPrice()
        {
            int price = 0;
            foreach(TripEncrypted attraction in Attractions)
            {
                price = price + Int32.Parse(TripAdvisorDecoder.Decode(attraction.Prices));        
            }
            price = price + Int32.Parse(BookingDatabaseDecoder.Decode(Accomodation.Price));
            return price;
        }
        public double getDayRating()
        {
            double rating = 0;
            foreach (TripEncrypted attraction in Attractions)
            {
                rating = rating + Int32.Parse(TripAdvisorDecoder.Decode(attraction.Ratings));
            }
            rating = rating + Int32.Parse(BookingDatabaseDecoder.Decode(Accomodation.Rating));
            rating = rating / (1 + Attractions.Length);
            return rating;
        }
    }
}
