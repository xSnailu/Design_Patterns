using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DatabaseIterators;

namespace TravelAgencies.DataAccess
{
	public class TripAdvisorDatabase : IDatabase<TripEncrypted>
	{
		public Guid[] Ids;
		public Dictionary<Guid, string>[] Names { get; set; }
		public Dictionary<Guid, string> Prices { get; set; }//Encrypted
		public Dictionary<Guid, string> Ratings { get; set; }//Encrypted
		public Dictionary<Guid, string> Countries { get; set; }

		public IDatabaseIterator<TripEncrypted> GetIterator()
		{
			return new TripAdvisorDatabaseIterator(this);
		}
	}

	public class TripEncrypted
	{
		private string name;
		private string prices;
		private string rating;
		private string coutries;

		public TripEncrypted(string name, string prices, string rating, string coutries)
		{
			this.name = name;
			this.prices = prices;
			this.rating = rating;
			this.coutries = coutries;
		}
		public string Names { get=>name; set=>name=value; }
		public string Prices { get => prices; set => prices = value; }//Encrypted
		public string Ratings { get => rating; set => rating = value; }//Encrypted
		public string Countries { get => coutries; set => coutries = value; }
	}
}

