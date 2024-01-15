using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLibrary.Models
{
	public class Audit
	{
		public int Id { get; set; }
		public DateTime Time { get; set; }
		public string Event { get; set; }
		public int IdUser { get; set; }
		public int? IdOffice { get; set; }
		public string GetDate
		{
			get
			{
				return Time.ToString("dd.MM.yyyy");
			}
		}

		public string GetTime
		{
			get
			{
				return Time.ToString("HH:mm");
			}
		}
		public string GetUserMail
		{
			get
			{
				return WorkingLibrary.SqlScripts.SelectSripts.SelectUserMailWithId(IdUser);
			}
		}
	}
}
