
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiniProjet.Models.Repositories
{
	public class FilmRepository : IFilmRepository
	{
		readonly ApplicationContext context;
		public FilmRepository(ApplicationContext context)
		{
			this.context = context;
		}
		public void Ajouter(Film film)
		{
			context.Films.Add(film);
			context.SaveChanges();
		}

		public Film GetFilmById(int id)
		{
			return context.Films.Find(id);
		}

		public IList<Film> GetFilmList()
		{
			return context.Films.OrderBy(film=> film.Titre).ToList();
		}

		public IList<Film> GetFilmsByCinemaId(int cinemaId)
		{
			return context.Films.Where(film => film.HostCinemaId == cinemaId).ToList();
		}

		public void MAJ(Film film)
		{
			Film film1 = context.Films.Find(film.Id);
			if (film1 != null)
			{
				film1.Titre = film.Titre;
				film1.Resume = film.Resume;
				film1.DatePublication =	film.DatePublication;
				film1.HostCinemaId = film.HostCinemaId;
				film1.Genre = film.Genre;
				film1.Poster = film.Poster;
				context.SaveChanges();
			}
		}

		public void Supprimer(Film film)
		{
			Film film1 = context.Films.Find(film.Id);
			if(film1 != null)
			{
				context.Films.Remove(film1);
				context.SaveChanges();
			}
		}
		public IList<Film> GetFilmsByTitle(string titre)
		{
			return context.Films.Where(film => film.Titre.ToUpper().Contains(titre.ToUpper())).ToList();
		}
    }
}
