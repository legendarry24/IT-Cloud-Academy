namespace ZooCodeFirst
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class ZooModel : DbContext
	{
		public ZooModel()
			: base("name=ZooModel1")
		{
		}

		public virtual DbSet<Animal> Animals { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Animal>()
				.Property(e => e.Name)
				.IsUnicode(false);
		}
	}
}
