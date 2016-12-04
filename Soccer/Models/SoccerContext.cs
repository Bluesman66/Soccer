using System.Data.Entity;

namespace Soccer.Models
{
	public class SoccerContext : DbContext
	{
		public DbSet<Player> Players { get; set; }
		public DbSet<Team> Teams { get; set; }
	}
}