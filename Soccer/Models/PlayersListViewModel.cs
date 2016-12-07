using System.Collections.Generic;
using System.Web.Mvc;

namespace Soccer.Models
{
	public class PlayersListViewModel
	{
		public IEnumerable<Player> Players { get; set; }
		public SelectList Teams { get; set; }
		public SelectList Positions { get; set; }
	}
}