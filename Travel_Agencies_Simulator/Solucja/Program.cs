using Solucja.TravelAgentsAbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;
using TravelAgencies.CodecMachine;
using TravelAgencies.DataAccess;
using TravelAgencies.DatabaseIterators;

namespace TravelAgencies
{
	class Program
	{
		static void Main(string[] args) { new Program().Run(); }

		private const int WebsitePermanentOfferCount = 2;
		private const int WebsiteTemporaryOfferCount = 3;
		private Random rd = new Random(257);

		//----------
		//YOUR CODE - additional fileds/properties/methods
		//----------


		public void Run()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			(
				BookingDatabase accomodationData, 
				TripAdvisorDatabase tripsData, 
				ShutterStockDatabase photosData, 
				OysterDatabase reviewData
			) = Init.Init.Run();

			//----------
			//YOUR CODE - set up everything
			ITravelAgency PolandAgency = new PolandTravelAgency(accomodationData, reviewData, photosData, tripsData);
			ITravelAgency ItalyAgency = new ItalyTravelAgency(accomodationData, reviewData, photosData, tripsData);
			ITravelAgency FranceAgency = new FranceTravelAgency(accomodationData, reviewData, photosData, tripsData);
			//----------

			while (true)
            {
				Console.Clear();

				//----------
				//YOUR CODE - run
				IOfferWebsite offerWebsite = new OfferWebsite();
				IAdvertisingAgency textAdvAgency = new TextOfferAdvertisingAgency();
				IAdvertisingAgency graphAdvAgency = new GraphicOfferAdvertisingAgency();

				for(int i=0; i<WebsitePermanentOfferCount; i++)
				{
					ITravelAgency currTravAgency = null;
					IAdvertisingAgency currAdvAgency = null;	
					int random = rd.Next() % 3;
					switch(random)
					{
						case 0:
							{
								currTravAgency = PolandAgency;
								break;
							}
						case 1:
							{
								currTravAgency = ItalyAgency;
								break;
							}
						case 2:
							{
								currTravAgency = FranceAgency;
								break;
							}
						default:
							{
								Console.WriteLine("Error");
								break;
							}
					}

					random = rd.Next() % 2;
					switch (random)
					{
						case 0:
							{
								currAdvAgency = textAdvAgency;
								break;
							}
						case 1:
							{
								currAdvAgency = graphAdvAgency;
								break;
							}
						default:
							{
								Console.WriteLine("Error");
								break;
							}
					}

					IOffer currOffer;
					int randomPhotosOrRevievs = rd.Next() % 4;
					currOffer = currAdvAgency.CreateConstantOffer(currTravAgency, randomPhotosOrRevievs);
					currAdvAgency.AddOffer(offerWebsite, currOffer);
				}

				for (int i = 0; i < WebsiteTemporaryOfferCount; i++)
				{
					ITravelAgency currTravAgency = null;
					IAdvertisingAgency currAdvAgency = null;
					int random = rd.Next() % 3;
					switch (random)
					{
						case 0:
							{
								currTravAgency = PolandAgency;
								break;
							}
						case 1:
							{
								currTravAgency = ItalyAgency;
								break;
							}
						case 2:
							{
								currTravAgency = FranceAgency;
								break;
							}
						default:
							{
								Console.WriteLine("Error");
								break;
							}
					}

					random = rd.Next() % 2;
					switch (random)
					{
						case 0:
							{
								currAdvAgency = textAdvAgency;
								break;
							}
						case 1:
							{
								currAdvAgency = graphAdvAgency;
								break;
							}
						default:
							{
								Console.WriteLine("Error");
								break;
							}
					}

					IOffer currOffer;
					int randomPhotosOrRevievs = rd.Next() % 5 + 1;
					// tutaj można dodać jeszcze jak dlugo ta temporary oferta ma być
					// temp to ilosc ticków po których oferta tymczasowa wygasa
					// tutaj jako aby było widac to te ticki są od 1 do 3 
					// czyli szansa ze jakaś wygasnie jest duza
					// jak sie nie ustawi temp to defaultowo jest równy 2
					int temp = rd.Next() % 3 + 1;
					currOffer = currAdvAgency.CreateTemporaryOffer(currTravAgency, randomPhotosOrRevievs, temp);
					currAdvAgency.AddOffer(offerWebsite, currOffer);

				}

				//----------
				//uncomment
				 Console.WriteLine("\n\n=======================FIRST PRESENT======================");
				// funkcje sie tutaj inaczej nazywają bo nie zobaczyłem tego wcześniej
				// to nie odkomentowywałem tylko zamiast zmieniac dałem te moje
				// offerWebsite.Present();
				offerWebsite.ShowWebsite();
				offerWebsite.NextTick();
                 Console.WriteLine("\n\n=======================SECOND PRESENT======================");
				// offerWebsite.Present();
				offerWebsite.ShowWebsite();
				offerWebsite.NextTick();
				Console.WriteLine("\n\n=======================THIRD PRESENT======================");
				// offerWebsite.Present();
				offerWebsite.ShowWebsite();
				offerWebsite.NextTick();


				if (HandleInput()) break;
			}
		}
		bool HandleInput()
		{
			var key = Console.ReadKey(true);
			return key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q;
		}
    }
}
