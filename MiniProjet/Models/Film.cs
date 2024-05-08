using System.ComponentModel.DataAnnotations;

namespace MiniProjet.Models
{
	public class Film
	{
		public int Id { get; set; }
		[Required]
		public string Titre { get; set; }
		[Required]
		public string Genre { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime DatePublication { get; set; }
		public string Resume { get; set; }
		[Required]
		public int HostCinemaId { get; set; }
		[Required(ErrorMessage ="Please select an image as a poster")]
		public string Poster { get; set; }
		public string CinemaName {  get; set; }

	}
}
