using Solucja.TravelAgentsAbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DataAccess;
using TravelAgencies.DatabaseIterators;

namespace TravelAgencies.Agencies
{

	public interface ITravelAgency
	{
		ITrip CreateTrip();
		IPhoto CreatePhoto();
		IReview CreateReview();
	}

	public class PolandTravelAgency : ITravelAgency
	{
		IDatabaseIterator<ListNode> ListNodeIterator;
		IDatabaseIterator<BSTNode> BSTNodeIterator;
		IDatabaseIterator<PhotMetadata> PhotMetadataIterator;
		IDatabaseIterator<TripEncrypted> EncryptedTripIterator;
		public Random rnd;

		public PolandTravelAgency(BookingDatabase bDB, OysterDatabase oDB ,ShutterStockDatabase ssDB, TripAdvisorDatabase tDB)
		{
			ListNodeIterator = bDB.GetIterator();
			BSTNodeIterator = oDB.GetIterator();
			PhotMetadataIterator = ssDB.GetIterator();
			EncryptedTripIterator = tDB.GetIterator();
			rnd = new Random(int.MinValue);
		}
		public IPhoto CreatePhoto()
		{
			PolandPhoto outputPhoto = null;
			do
			{
				PhotMetadata photo = PhotMetadataIterator.CurrentItem();
				if(photo.Longitude > 14.4 && photo.Longitude < 23.5)
					if(photo.Latitude > 49.8 && photo.Latitude < 54.2)
					{
						outputPhoto = new PolandPhoto(photo);
					}
				PhotMetadataIterator.Next();

			}while (outputPhoto == null);

			return outputPhoto;
		}

		public IReview CreateReview()
		{
			PolandReview outputReviev = null;
			outputReviev = new PolandReview(BSTNodeIterator.CurrentItem());
			BSTNodeIterator.Next();
			return outputReviev;
		}

		public ITrip CreateTrip()
		{
			
			int numberOfDays = rnd.Next(1, 5);
			Day[] tripDays = new Day[numberOfDays];
			for(int i=0; i<tripDays.Length; i++)
			{
				tripDays[i] = new Day();
				tripDays[i].AddAccomodation(ListNodeIterator.CurrentItem());
				ListNodeIterator.Next();

				int attractionsAdded = 0;
				do
				{
					TripEncrypted te = EncryptedTripIterator.CurrentItem();
					EncryptedTripIterator.Next();

					if(te.Countries == "Poland")
					{
						attractionsAdded++;
						tripDays[i].AddAtraction(te);
					}
				}
				while (attractionsAdded < 3);
			}

			return new PolandTrip(tripDays);

		}
	}

	public class ItalyTravelAgency : ITravelAgency
	{
		IDatabaseIterator<ListNode> ListNodeIterator;
		IDatabaseIterator<BSTNode> BSTNodeIterator;
		IDatabaseIterator<PhotMetadata> PhotMetadataIterator;
		IDatabaseIterator<TripEncrypted> EncryptedTripIterator;
		public Random rnd;
		public ItalyTravelAgency(BookingDatabase bDB, OysterDatabase oDB, ShutterStockDatabase ssDB, TripAdvisorDatabase tDB)
		{
			ListNodeIterator = bDB.GetIterator();
			BSTNodeIterator = oDB.GetIterator();
			PhotMetadataIterator = ssDB.GetIterator();
			EncryptedTripIterator = tDB.GetIterator();
			rnd = new Random(int.MaxValue);
		}
		public IPhoto CreatePhoto()
		{
			ItalyPhoto outputPhoto = null;
			do
			{
				PhotMetadata photo = PhotMetadataIterator.CurrentItem();
				if (photo.Longitude > 8.8 && photo.Longitude < 15.2)
					if (photo.Latitude > 37.7 && photo.Latitude < 44.0)
					{
						outputPhoto = new ItalyPhoto(photo);
					}
				PhotMetadataIterator.Next();

			} while (outputPhoto == null);

			return outputPhoto;
		}

		public IReview CreateReview()
		{
			ItalyReview outputReviev = null;
			outputReviev = new ItalyReview(BSTNodeIterator.CurrentItem());
			BSTNodeIterator.Next();
			return outputReviev;
		}

		public ITrip CreateTrip()
		{
			
			int numberOfDays = rnd.Next(1, 5);
			Day[] tripDays = new Day[numberOfDays];
			for (int i = 0; i < tripDays.Length; i++)
			{
				tripDays[i] = new Day();
				tripDays[i].AddAccomodation(ListNodeIterator.CurrentItem());
				ListNodeIterator.Next();

				int attractionsAdded = 0;
				do
				{
					TripEncrypted te = EncryptedTripIterator.CurrentItem();
					EncryptedTripIterator.Next();

					if (te.Countries == "Italy")
					{
						attractionsAdded++;
						tripDays[i].AddAtraction(te);
					}
				}
				while (attractionsAdded < 3);
			}

			return new ItalyTrip(tripDays);

		}
	}

	public class FranceTravelAgency : ITravelAgency
	{
		IDatabaseIterator<ListNode> ListNodeIterator;
		IDatabaseIterator<BSTNode> BSTNodeIterator;
		IDatabaseIterator<PhotMetadata> PhotMetadataIterator;
		IDatabaseIterator<TripEncrypted> EncryptedTripIterator;
		public Random rnd;
		public FranceTravelAgency(BookingDatabase bDB, OysterDatabase oDB, ShutterStockDatabase ssDB, TripAdvisorDatabase tDB)
		{
			ListNodeIterator = bDB.GetIterator();
			BSTNodeIterator = oDB.GetIterator();
			PhotMetadataIterator = ssDB.GetIterator();
			EncryptedTripIterator = tDB.GetIterator();
			rnd = new Random(int.MaxValue - 55);
		}
		public IPhoto CreatePhoto()
		{
			FrancePhoto outputPhoto = null;
			do
			{
				PhotMetadata photo = PhotMetadataIterator.CurrentItem();
				if (photo.Longitude > 0 && photo.Longitude < 5.4)
					if (photo.Latitude > 43.6 && photo.Latitude < 50.0)
					{
						outputPhoto = new FrancePhoto(photo);
					}
				PhotMetadataIterator.Next();

			} while (outputPhoto == null);

			return outputPhoto;
		}

		public IReview CreateReview()
		{
			FranceReview outputReviev = null;
			outputReviev = new FranceReview(BSTNodeIterator.CurrentItem());
			BSTNodeIterator.Next();
			return outputReviev;
		}

		public ITrip CreateTrip()
		{
		
			int numberOfDays = rnd.Next(1, 5);
			Day[] tripDays = new Day[numberOfDays];
			for (int i = 0; i < tripDays.Length; i++)
			{
				tripDays[i] = new Day();
				tripDays[i].AddAccomodation(ListNodeIterator.CurrentItem());
				ListNodeIterator.Next();

				int attractionsAdded = 0;
				do
				{
					TripEncrypted te = EncryptedTripIterator.CurrentItem();
					EncryptedTripIterator.Next();

					if (te.Countries == "France")
					{
						attractionsAdded++;
						tripDays[i].AddAtraction(te);
					}
				}
				while (attractionsAdded < 3);
			}

			return new FranceTrip(tripDays);

		}
	}

}