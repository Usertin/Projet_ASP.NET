using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace MiniProjet.Models
{
	public class ApplicationContext : IdentityDbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}
		public DbSet<Film> Films{ get; set; }
		public DbSet<Cinema> Cinemas { get; set; }
	}

}
