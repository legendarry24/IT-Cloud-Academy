using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital
{
	class Patient
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		[Required]
		[StringLength(35)]
		public string Name { get; set; }

		[Required]
		public int? Age { get; set; }
	}
}
