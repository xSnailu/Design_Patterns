using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;

namespace TravelAgencies
{
    interface IAdvertisingAgency
    {
        IOffer CreateTemporaryOffer(ITravelAgency travelAgency, int numberOfReviews, int maxTick = 2);
        IOffer CreateConstantOffer(ITravelAgency travelAgency, int numberOfReviews);

        void AddOffer(IOfferWebsite website,IOffer offer);
    }

    public class TextOfferAdvertisingAgency : IAdvertisingAgency
    {
        public void AddOffer(IOfferWebsite website, IOffer offer)
        {
            website.AddOffer(offer);
        }

        public IOffer CreateConstantOffer(ITravelAgency travelAgency, int numberOfReviews)
        {
            TextOffer outputOffer = new TextOffer();
            outputOffer.AddTrip(travelAgency.CreateTrip());
            for (int i = 0; i < numberOfReviews; i++)
                outputOffer.AddReviev(travelAgency.CreateReview());

            return outputOffer;
        }

        public IOffer CreateTemporaryOffer(ITravelAgency travelAgency, int numberOfReviews, int maxTick = 2)
        {
            TemporaryTextOffer outputOffer = new TemporaryTextOffer(maxTick);
            outputOffer.AddTrip(travelAgency.CreateTrip());
            for (int i = 0; i < numberOfReviews; i++)
                outputOffer.AddReviev(travelAgency.CreateReview());

            return outputOffer;
        }
    }

    public class GraphicOfferAdvertisingAgency : IAdvertisingAgency
    {
        public void AddOffer(IOfferWebsite website, IOffer offer)
        {
            website.AddOffer(offer);
        }

        public IOffer CreateConstantOffer(ITravelAgency travelAgency, int numberOfPhotos)
        {
            GraphicOffer outputOffer = new GraphicOffer();
            outputOffer.AddTrip(travelAgency.CreateTrip());
            for (int i = 0; i < numberOfPhotos; i++)
                outputOffer.AddPhoto(travelAgency.CreatePhoto());

            return outputOffer;
        }

        public IOffer CreateTemporaryOffer(ITravelAgency travelAgency, int numberOfPhotos, int maxTick = 2)
        {
            TemporaryGraphicOffer outputOffer = new TemporaryGraphicOffer(maxTick);
            outputOffer.AddTrip(travelAgency.CreateTrip());
            for (int i = 0; i < numberOfPhotos; i++)
                outputOffer.AddPhoto(travelAgency.CreatePhoto());

            return outputOffer;
        }
    }

}
