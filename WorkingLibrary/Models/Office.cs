using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLibrary.Models
{
	public class Office
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Region { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public int? House { get; set; }
		public string Description { get; set; }
	}
}
	