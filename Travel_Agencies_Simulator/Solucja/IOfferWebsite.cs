using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies
{
    public interface IOfferWebsite
    {
        void ShowWebsite();
        void NextTick();
        void AddOffer(IOffer offer);

    }

    class OfferWebsite : IOfferWebsite
    {
        List<IOffer> offerList;

        public OfferWebsite()
        {
            offerList = new List<IOffer>();
        }
        public void AddOffer(IOffer offer)
        {
            offerList.Add(offer);
        }
        public void NextTick()
        {
            foreach (IOffer offer in offerList)
                offer.NextTick();
        }

        public void ShowWebsite()
        {
            foreach (IOffer offer in offerList)
                offer.ShowOffer();
        }
    }
}
