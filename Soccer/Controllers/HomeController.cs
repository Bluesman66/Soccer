using Soccer.Models;
using System.Linq;
using System.Web.Mvc;

namespace Soccer.Controllers
{
	public class HomeController : Controller
	{
		SoccerContext db = new SoccerContext();

		// Выводим всех футболистов
		public ActionResult Index()
		{
			var players = db.Players.Include("Team");
			return View(players.ToList());
		}

		public ActionResult TeamDetails(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			Team team = db.Teams.Include("Players").FirstOrDefault(t => t.Id == id);
			if (team == null)
			{
				return HttpNotFound();
			}
			return View(team);
		}
	}
}