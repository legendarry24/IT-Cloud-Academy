using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
	public class PhoneConfig
	{
		[Key]
		[ForeignKey("Phone")]
		public int Id { get; set; }
		public string Resolution { get; set; }
		public string Proccess { get; set; }

		public Phone Phone { get; set; }

	}
}
