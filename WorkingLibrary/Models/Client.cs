using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLibrary.Models
{
	public class Client
	{
		public int Id { get; set; }
		public string Surname { get; set; }
		public string Name { get; set; }
		public string Patronymic { get; set; }
		public string Phone { get; set; }
		public string Mail { get; set; }
		public DateTime CreateDate { get; set; }
		public bool Company { get; set; }
		public string Description { get; set; }	
		public int? IdUser { get; set; }
		public int IdOffice { get; set; }
		public string GetCreateDate
		{
			get
			{
				return CreateDate.ToString("dd.MM.yyyy");
			}
		}
		public string GetCompany
		{
			get
			{
				if (Company)
				{
					return "Юр-лицо";
				}

				return "Физ-лицо";
			}
		}

		public string GetOfficeName
		{
			get
			{
				return WorkingLibrary.SqlScripts.SelectSripts.SelectOfficeNameWitId(IdOffice);
			}
		}
	}
}
