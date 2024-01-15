using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLibrary.Models
{
	public class Sale
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		public int Price { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public int IdGood { get; set; }
		public int? IdUser { get; set; }
		public int IdOffice { get; set; }

		public string GetGoodName
		{
			get
			{
				return WorkingLibrary.SqlScripts.SelectSripts.SelectGoodWithId(IdGood);
			}
		}

		public string GetOfficeName
		{
			get
			{
				return WorkingLibrary.SqlScripts.SelectSripts.SelectOfficeNameWitId(IdOffice);
			}
		}

		public string GetUserMail
		{
			get
			{
				return WorkingLibrary.SqlScripts.SelectSripts.SelectUserMailWithId(IdUser);
			}
		}

		public string GetDate
		{
			get
			{
				return Date.ToString("dd.MM.yyyy");
			}
		}
	}
}
