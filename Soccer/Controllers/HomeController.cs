using Soccer.Models;
using System.Data.Entity;
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

		[HttpGet]
		public ActionResult Create()
		{
			// Формируем список команд для передачи в представление
			SelectList teams = new SelectList(db.Teams, "Id", "Name");
			ViewBag.Teams = teams;
			return View();
		}

		[HttpPost]
		public ActionResult Create(Player player)
		{
			//Добавляем игрока в таблицу
			db.Players.Add(player);
			db.SaveChanges();
			// перенаправляем на главную страницу
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			// Находим в бд футболиста
			Player player = db.Players.Find(id);
			if (player != null)
			{
				// Создаем список команд для передачи в представление
				SelectList teams = new SelectList(db.Teams, "Id", "Name", player.TeamId);
				ViewBag.Teams = teams;
				return View(player);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Edit(Player player)
		{
			db.Entry(player).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}