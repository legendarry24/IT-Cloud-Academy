using System.Data.Entity;

namespace ZooCodeSecond
{
	class ZooContext : DbContext
	{
		public DbSet<Animal> Animals { get; set; }
	}
}
