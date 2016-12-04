using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Soccer.Models
{
	public class SoccerDbInitializer : DropCreateDatabaseAlways<SoccerContext>
	{
		protected override void Seed(SoccerContext context)
		{
			context.Players.Add(new Player { Id = 1, Name = "Месси", Age = 26, Position = "Нападающий", TeamId = 2 });
			context.Players.Add(new Player { Id = 2, Name = "Роналду", Age = 29, Position = "Нападающий", TeamId = 1 });
			context.Players.Add(new Player { Id = 3, Name = "Бейл", Age = 24, Position = "Полузащитник", TeamId = 1 });
			context.Players.Add(new Player { Id = 4, Name = "Неймар", Age = 22, Position = "Нападающий", TeamId = 2 });
			context.Players.Add(new Player { Id = 5, Name = "Иньеста", Age = 29, Position = "Полузащитник", TeamId = 2 });
			context.Players.Add(new Player { Id = 6, Name = "Рибери", Age = 30, Position = "Полузащитник", TeamId = 3 });

			context.Teams.Add(new Team { Id = 1, Name = "Реал Мадрид", Coach = "Анчелотти" });
			context.Teams.Add(new Team { Id = 2, Name = "Реал Мадрид", Coach = "Анчелотти" });
			context.Teams.Add(new Team { Id = 3, Name = "Бавария", Coach = "Гуардиола" });
			context.Teams.Add(new Team { Id = 4, Name = "Боруссия", Coach = "Клопп" });

			base.Seed(context);
		}
	}
}