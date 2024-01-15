using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLibrary.Models
{
	public class Deal
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Cost { get; set; }
		public string Street { get; set; }
		public int? House { get; set; }
		public int? Flat { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? ProvisionDate { get; set; }
		public string Description { get; set; }
		public int? IdStatus { get; set; }
		public int IdClient { get; set; }
		public int IdOffice { get; set; }
		public int? IdUser { get; set; }
		public int? IdService { get; set; }
		private DateTime _provisionDate { get; set; }

		public string GetCreateDate
		{
			get
			{
				return CreateDate.ToString("dd.MM.yyyy");
			}
		}

		public string GetProvisionDate
		{
			get
			{
				if (ProvisionDate != null)
				{
					_provisionDate = Convert.ToDateTime(ProvisionDate);
				}
				else
				{
					return "Нет даты";
				}

				return _provisionDate.ToString("dd.MM.yyyy"); ;
			}
		}

		public string GetCost
		{
			get
			{
				return Cost.ToString() + "Р";
			}
		}

		public string GetClient
		{
			get
			{
				return WorkingLibrary.SqlScripts.SelectSripts.SelectClientPhoneWithId(IdClient);
			}
		}

		public string GetUser
		{
			get
			{
				return WorkingLibrary.SqlScripts.SelectSripts.SelectUserMailWithId(IdUser);
			}
		}

		public string GetService
		{
			get
			{
				return WorkingLibrary.SqlScripts.SelectSripts.SelectServiceNameWithId(IdService);
			}
		}

		public string GetOffice
		{
			get
			{
				return WorkingLibrary.SqlScripts.SelectSripts.SelectOfficeNameWitId(IdOffice);
			}
		}
	}
}
