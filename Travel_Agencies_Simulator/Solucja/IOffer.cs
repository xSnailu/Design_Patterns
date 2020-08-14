using Solucja.TravelAgentsAbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies
{
    public interface IOffer
    {
        void NextTick();
        void ShowOffer();
    }

    class GraphicOffer : IOffer
    {
        protected ITrip trip;
        protected List<IPhoto> photos;

        public GraphicOffer()
        {
            photos = new List<IPhoto>();
        }

        public void AddTrip(ITrip trip)
        {
            this.trip = trip;
        }
        public void AddPhoto(IPhoto photo)
        {
            photos.Add(photo);
        }
        virtual public void NextTick()
        {
            return;
        }
        virtual public void ShowOffer()
        {
            trip.ShowContent();
            Console.WriteLine();
            foreach (IPhoto photo in photos)
                photo.ShowContent();
            Console.WriteLine();
        }
    }

    class TextOffer : IOffer
    {
        protected ITrip trip;
        protected List<IReview> reviews;

        public TextOffer()
        {
            reviews = new List<IReview>();
        }

        public void AddTrip(ITrip trip)
        {
            this.trip = trip;
        }
        public void AddReviev(IReview review)
        {
            reviews.Add(review);
        }
        virtual public void NextTick()
        {
            return;
        }
        virtual public void ShowOffer()
        {
            trip.ShowContent();
            Console.WriteLine();
            foreach (IReview review in reviews)
                review.ShowContent();
            Console.WriteLine();
        }
    }

    class TemporaryGraphicOffer : GraphicOffer
    {

        
        
        int tick = 0;
        int maxTick = 2; // defautlowo dwa
        public TemporaryGraphicOffer(int maxTick)
        {
            photos = new List<IPhoto>();
            this.maxTick = maxTick;
        }

        override public void NextTick()
        {
            tick++;
        }
        override public void ShowOffer()
        {
            if (tick >= maxTick)
            {
                Console.WriteLine("This offer is expired");
                Console.WriteLine();
                return;
            }

            trip.ShowContent();
            Console.WriteLine();
            foreach (IPhoto photo in photos)
                photo.ShowContent();
            Console.WriteLine();
        }
    }

    

    class TemporaryTextOffer : TextOffer
    {
        
        
        int tick = 0;
        int maxTick = 2; // defautlowo dwa
        public TemporaryTextOffer(int maxTick)
        {
            reviews = new List<IReview>();
            this.maxTick = maxTick;
        }

        override public void NextTick()
        {
            tick++;
        }
        override public void ShowOffer()
        {
            if(tick >= maxTick)
            {
                Console.WriteLine("This offer is expired");
                Console.WriteLine();
                return;
            }

            trip.ShowContent();
            Console.WriteLine();
            foreach (IReview review in reviews)
                review.ShowContent();
            Console.WriteLine();
        }
    }

   
    

}
