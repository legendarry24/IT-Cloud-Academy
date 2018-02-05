using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital
{
	class Doctor
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		[Required]
		[StringLength(35)]
		public string Name { get; set; }

		public int? Age { get; set; }
	}
}
