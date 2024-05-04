using System.ComponentModel.DataAnnotations;

namespace MiniProjet.Models
{
	public class Cinema
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Adresse { get; set; }
		public IList<Film> listFilms { get; set; }
	}
}
