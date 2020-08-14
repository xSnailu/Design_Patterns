using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.CodecMachine;
using TravelAgencies.DataAccess;

namespace Solucja.TravelAgentsAbstractFactory
{
    public interface IPhoto
    {
        void ShowContent();
    }

    class PolandPhoto : IPhoto
    {
        PhotMetadata photo;
        public PolandPhoto(PhotMetadata photo)
        {
            this.photo = photo;
        }

        public void ShowContent()
        {
            string photoName = photo.Name;
            photoName.Replace('s', 'ś');
            photoName.Replace('c', 'ć');
            Console.WriteLine("{0} ({1}x{2})", photoName, ShutterStockDecoder.Decode(photo.WidthPx), ShutterStockDecoder.Decode(photo.HeightPx));
        }
    }
    class ItalyPhoto : IPhoto
    {
        PhotMetadata photo;
        public ItalyPhoto(PhotMetadata photo)
        {
            this.photo = photo;
        }

        public void ShowContent()
        {
            string photoName = photo.Name;
            photoName = "Dello_" + photoName;
            Console.WriteLine("{0} ({1}x{2})", photoName, ShutterStockDecoder.Decode(photo.WidthPx), ShutterStockDecoder.Decode(photo.HeightPx));
        }
    }
    class FrancePhoto : IPhoto
    {
        PhotMetadata photo;
        public FrancePhoto(PhotMetadata photo)
        {
            this.photo = photo;
        }

        public void ShowContent()
        {
            string photoName = photo.Name;
            Console.WriteLine("{0} ({1}x{2})", photoName, ShutterStockDecoder.Decode(photo.WidthPx), ShutterStockDecoder.Decode(photo.HeightPx));
        }
    }
}
