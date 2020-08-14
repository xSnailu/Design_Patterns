using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DatabaseIterators;

namespace TravelAgencies.DataAccess
{
	public class PhotMetadata
	{
		public string Name { get; set; }
		public string Camera { get; set; }
		public double[] CameraSettings { get; set; }
		public DateTime Date { get; set; }
		public string WidthPx { get; set; }//Encrypted
		public string HeightPx { get; set; }//Encrypted
		public double Longitude { get; set; }
		public double Latitude { get; set; }
	}
	public class ShutterStockDatabase : IDatabase<PhotMetadata>
	{
		public PhotMetadata[][][] Photos;

		public IDatabaseIterator<PhotMetadata> GetIterator()
		{
			return new ShutterStockDatabaseIterator(this);
		}
	}
}
