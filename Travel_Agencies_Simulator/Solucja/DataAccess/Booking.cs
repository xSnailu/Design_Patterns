﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DatabaseIterators;

namespace TravelAgencies.DataAccess
{
	public class ListNode
	{
		public ListNode Next { get; set; }
		public string Name { get; set; }
		public string Rating { get; set; }//Encrypted
		public string Price { get; set; }//Encrypted
	}
	public class BookingDatabase : IDatabase<ListNode>
	{
		public ListNode[] Rooms { get; set; }

		public IDatabaseIterator<ListNode> GetIterator()
		{
			return new BookingDatabaseIterator(this);
		}
	}
}
