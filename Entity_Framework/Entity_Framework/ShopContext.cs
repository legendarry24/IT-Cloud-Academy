using System.Data.Entity;

namespace Entity_Framework
{
	public class ShopContext : DbContext
	{
		private const string ConnectionString = "ShopConnectionString";

		public ShopContext() : base(ConnectionString)
		{}

		public DbSet<Phone> Phones { get; set; }
		public DbSet<Laptop> Laptops { get; set; }
	    public DbSet<Department> Departments { get; set; }
	}
}
