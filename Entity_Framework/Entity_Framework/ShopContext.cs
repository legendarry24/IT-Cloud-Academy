using System.Data.Entity;

namespace Entity_Framework
{
	//class MyInitializer : DropCreateDatabaseAlways<ShopContext>
	//{
	//	protected override void Seed(ShopContext context)
	//	{
	//		context.Humans.Add(new Person() { Id = 1, Name = "Test" });
	//		context.SaveChanges();
	//	}
	//}

	public class ShopContext : DbContext
	{
		private const string ConnectionString = "ShopConnectionString";

		//static ShopContext()
		//{
		//	Database.SetInitializer<ShopContext>(new MyInitializer());
		//}

		public ShopContext() : base(ConnectionString)
		{}

		public DbSet<Phone> Phones { get; set; }
		public DbSet<Laptop> Laptops { get; set; }
	    public DbSet<Department> Departments { get; set; }
		public DbSet<PhoneConfig> PhoneConfig { get; set; }
		public DbSet<Person> Humans { get; set; }
	}
}
