using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooCodeSecond
{
	class ZooContext : DbContext
	{
		public DbSet<Animal> Animals { get; set; }
	}
}
