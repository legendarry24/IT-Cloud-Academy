using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework
{
	public class PhoneConfig
	{
        //one-to-one relationship 
        [Key]
		[ForeignKey("Phone")]
		public int Id { get; set; }
		public string Resolution { get; set; }
		public string Proccess { get; set; }

		public Phone Phone { get; set; }

	}
}
