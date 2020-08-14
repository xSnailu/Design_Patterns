using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DatabaseIterators;

//Oyster is a website with reviews of various holiday destinations.
namespace TravelAgencies.DataAccess
{
	public class BSTNode 
	{
		public string Review { get; set; }
		public string UserName { get; set; }
		public BSTNode Left { get; set; }
		public BSTNode Right { get; set; }
	}
	public class OysterDatabase : IDatabase<BSTNode>
	{
		public BSTNode Reviews { get; set; }

		public IDatabaseIterator<BSTNode> GetIterator()
		{
			return new OysterDatabaseIterator(this);
		}
	}

}
