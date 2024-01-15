using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLibrary.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string Surname { get; set; }
		public string Name { get; set; }
		public string Patronymic { get; set; }
		public string Phone { get; set; }
		public string Mail { get; set; }
		public byte[] Image { get; set; }
		public string Description { get; set; }
		public bool Ban { get; set; }
		public int InvitationCode { get; set; }
		public int? IdUserRole { get; set; }
		public int? IdOffice { get; set; }

		public string GetUserRoleName
		{
			get
			{
				return WorkingLibrary.SqlScripts.SelectSripts.SelectUserRoleNameWithId(IdUserRole);
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
