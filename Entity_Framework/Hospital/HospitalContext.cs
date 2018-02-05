using System.Data.Entity;

namespace Hospital
{
	class HospitalContext : DbContext
	{
		private const string ConnectionString = "HospitalContext";

		public HospitalContext() : base(ConnectionString)
		{ }

		public DbSet<Patient> Patients { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
	}
}
