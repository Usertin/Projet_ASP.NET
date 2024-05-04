namespace MiniProjet.Models.Repositories
{
	public interface ICinemaRepository
	{
		IList<Cinema> GetCinemaList();
		Cinema GetCinemaById(int id);
		void Ajouter(Cinema cinema);
		void MAJ(Cinema cinema);
		void Supprimer(Cinema cinema);
		int FilmCount(int filmId);
	}
}
