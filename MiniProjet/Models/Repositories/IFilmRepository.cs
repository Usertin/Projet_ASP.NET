namespace MiniProjet.Models.Repositories
{
	public interface IFilmRepository
	{
		IList<Film> GetFilmList();
		Film GetFilmById(int id);
		void Ajouter(Film film);
		void MAJ (Film film);
		void Supprimer(Film film);
		IList<Film> GetFilmsByTitle(string title);
		IList<Film> GetFilmsByCinemaId(int cinemaId);
	}
}
