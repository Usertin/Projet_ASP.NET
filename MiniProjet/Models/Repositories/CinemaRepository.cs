
namespace MiniProjet.Models.Repositories
{
	public class CinemaRepository : ICinemaRepository
	{
		readonly ApplicationContext context;
		public CinemaRepository(ApplicationContext context) {
			this.context = context;
		}
		public void Ajouter(Cinema cinema)
		{
			context.Cinemas.Add(cinema);
			context.SaveChanges();
		}

		public int FilmCount(int filmId)
		{
			return context.Films.Where(film => film.Id == filmId).Count();
		}

		public Cinema GetCinemaById(int id)
		{
			return context.Cinemas.Find(id);
		}

		public IList<Cinema> GetCinemaList()
		{
			return context.Cinemas.OrderBy(cinema => cinema.Name).ToList();
		}

		public void MAJ(Cinema cinema)
		{
			Cinema cinema1 = context.Cinemas.Find(cinema.Id);
			if(cinema1 != null)
			{
				cinema1.Adresse = cinema.Adresse;
				cinema1.Name = cinema.Name;
				cinema1.listFilms = cinema.listFilms;
				context.SaveChanges();
			}
		}

		public void Supprimer(Cinema cinema)
		{
			Cinema cinema1 = context.Cinemas.Find(cinema.Id);
			if(cinema1 != null)
			{
				context.Cinemas.Remove(cinema1);
				context.SaveChanges();
			}
		}
	}
}
