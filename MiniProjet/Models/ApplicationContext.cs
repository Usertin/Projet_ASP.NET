using Microsoft.EntityFrameworkCore;
namespace MiniProjet.Models
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}
		public DbSet<Film> Films{ get; set; }
		public DbSet<Cinema> Cinemas { get; set; }
	}

}
