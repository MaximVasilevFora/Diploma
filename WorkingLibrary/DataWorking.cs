using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WorkingLibrary
{
	public class DataWorking
	{
		private const string _emptyUserImage = @"D:\Maxima\WPF Application\JustCleanDiploma\JustCleanDiploma\Images\Profil.png";
		private const string _emptyGoodImage = @"D:\Maxima\WPF Application\JustCleanDiploma\JustCleanDiploma\Images\EmptyGood.png";
		private int? nullInt = null;
		private DateTime? nullDateTime = null;

		public int GetInvitationCode()
		{
			var random = new Random();
			var code = SqlScripts.SelectSripts.SelectLastUserId().ToString();

			code += 0;

			while (code.Length < 6)
			{
				code += random.Next(1, 10);
			}

			return Convert.ToInt32(code);
		}

		public byte[] ImageToByte(System.Drawing.Image img)
		{
			ImageConverter converter = new ImageConverter();

			return (byte[])converter.ConvertTo(img, typeof(byte[]));
		}

		public BitmapImage GetBitmapImage(byte[] array)
		{
			BitmapImage bi;

			using (var ms = new MemoryStream(array))
			{
				bi = new BitmapImage();
				bi.BeginInit();
				bi.CreateOptions = BitmapCreateOptions.None;
				bi.CacheOption = BitmapCacheOption.OnLoad;
				bi.StreamSource = ms;

				bi.EndInit();
			}

			return bi;
		}

		public byte[] BitmapImageInArray(BitmapImage imageSource)
		{
			byte[] data;
			JpegBitmapEncoder encoder = new JpegBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(imageSource));

			using (MemoryStream ms = new MemoryStream())
			{
				encoder.Save(ms);
				data = ms.ToArray();
			}

			return data;
		}

		public static List<string> EventType = new List<string>()
		{
			"Авторизация в системе",
			"Добавление информации о новом клиенте",
			"Добавление информации о новом товаре",
			"Добавление информации о новой заявке",
			"Добавление информации о новом поставщике",
			"Добавление информации о продаже",
			"Добавление информации о новой услуге",
			"Добавление информации о новом пользователе",
			"Добавление информации о новом пользователе по пригласительному коду",
			"Изменение информации о клиенте",
			"Удаление информации о клиенте",
			"Изменение информации о товаре",
			"Удаление информации о клиенте",
			"Изменение информации о заказе",
			"Удаление информации о заказе",
			"Изменение информации о поставщике",
			"Удаление информации о поставщике",
			"Изменение информации о продаже",
			"Удаление информации о продаже",
			"Изменение информации об услуге",
			"Удаление информации об услуге",
			"Изменение информации о сотруднике",
			"Удаление информации о сотруднике",
			"Выход из системы",
		};

		public List<Models.UserRole> GetUserRoles(DataTable dataTable)
		{
			var userRoles = new List<Models.UserRole>();

			foreach (var dataRow in dataTable.Select())
			{
				userRoles.Add(new Models.UserRole
				{
					Id = Convert.ToInt32(dataRow[0]),
					Name = Convert.ToString(dataRow[1]),
					Description = dataRow[2] != System.DBNull.Value ? Convert.ToString(dataRow[2]) : null,
				});
			}

			return userRoles;
		}

		public List<Models.User> GetUsers(DataTable dataTable)
		{
			var users = new List<Models.User>();

			foreach (var dataRow in dataTable.Select())
			{
				users.Add(new Models.User
				{
					Id = Convert.ToInt32(dataRow[0]),
					Login = dataRow[1] != System.DBNull.Value ? Convert.ToString(dataRow[1]) : null,
					Password = dataRow[2] != System.DBNull.Value ? Convert.ToString(dataRow[2]) : null,
					Surname = dataRow[3] != System.DBNull.Value ? Convert.ToString(dataRow[3]) : null,
					Name = Convert.ToString(dataRow[4]),
					Patronymic = dataRow[5] != System.DBNull.Value ? Convert.ToString(dataRow[5]) : null,
					Phone = dataRow[6] != System.DBNull.Value ? Convert.ToString(dataRow[6]) : null,
					Mail = Convert.ToString(dataRow[7]),
					Image = dataRow[8] == System.DBNull.Value ? ImageToByte(new Bitmap(_emptyUserImage)) : (byte[])dataRow[8],
					Description = dataRow[9] != System.DBNull.Value ? Convert.ToString(dataRow[9]) : null,
					Ban = Convert.ToBoolean(dataRow[10]),
					InvitationCode = Convert.ToInt32(dataRow[11]),
					IdUserRole = dataRow[12] != System.DBNull.Value ? Convert.ToInt32(dataRow[12]) : nullInt,
					IdOffice = dataRow[13] != System.DBNull.Value ? Convert.ToInt32(dataRow[13]) : nullInt
				});
			}

			return users;
		}

		public List<Models.Client> GetClients(DataTable dataTable)
		{
			var clients = new List<Models.Client>();

			foreach (var dataRow in dataTable.Select())
			{
				clients.Add(new Models.Client
				{
					Id = Convert.ToInt32(dataRow[0]),
					Surname = dataRow[1] != System.DBNull.Value ? Convert.ToString(dataRow[1]) : null,
					Name = Convert.ToString(dataRow[2]),
					Patronymic = dataRow[3] != System.DBNull.Value ? Convert.ToString(dataRow[3]) : null,
					Phone = Convert.ToString(dataRow[4]),
					Mail = dataRow[5] != System.DBNull.Value ? Convert.ToString(dataRow[5]) : null,
					CreateDate = Convert.ToDateTime(dataRow[6]),
					Company = Convert.ToBoolean(dataRow[7]),
					Description = dataRow[8] != System.DBNull.Value ? Convert.ToString(dataRow[8]) : null,
					IdUser = dataRow[9] != System.DBNull.Value ? Convert.ToInt32(dataRow[9]) : nullInt,
					IdOffice = Convert.ToInt32(dataRow[10])
				});
			}

			return clients;
		}

		public List<Models.Office> GetOffices(DataTable dataTable)
		{
			var offices = new List<Models.Office>();

			foreach (var dataRow in dataTable.Select())
			{
				offices.Add(new Models.Office
				{
					Id = Convert.ToInt32(dataRow[0]),
					Name = Convert.ToString(dataRow[1]),
					Region = dataRow[2] != System.DBNull.Value ? Convert.ToString(dataRow[2]) : null,
					City = Convert.ToString(dataRow[3]),
					Street = dataRow[4] != System.DBNull.Value ? Convert.ToString(dataRow[4]) : null,
					House = dataRow[5] != System.DBNull.Value ? Convert.ToInt32(dataRow[5]) : nullInt,
					Description = dataRow[6] != System.DBNull.Value ? Convert.ToString(dataRow[6]) : null,
				});
			}

			return offices;
		}

		public List<Models.Good> GetGoods(DataTable dataTable)
		{
			var goods = new List<Models.Good>();

			foreach (var dataRow in dataTable.Select())
			{
				goods.Add(new Models.Good
				{
					Id = Convert.ToInt32(dataRow[0]),
					Name = Convert.ToString(dataRow[1]),
					PurchasePrice = Convert.ToInt32(dataRow[2]),
					SalePrice = Convert.ToInt32(dataRow[3]),
					Image = dataRow[4] == System.DBNull.Value ? ImageToByte(new Bitmap(_emptyGoodImage)) : (byte[])dataRow[4],
					Description = dataRow[5] != System.DBNull.Value ? Convert.ToString(dataRow[5]) : null,
					IdProvider = dataRow[6] != System.DBNull.Value ? Convert.ToInt32(dataRow[6]) : nullInt,
					IdOffice = Convert.ToInt32(dataRow[7])
				});
			}

			return goods;
		}

		public List<Models.Provider> GetProviders(DataTable dataTable)
		{
			var providers = new List<Models.Provider>();

			foreach (var dataRow in dataTable.Select())
			{
				providers.Add(new Models.Provider
				{
					Id = Convert.ToInt32(dataRow[0]),
					Name = Convert.ToString(dataRow[1]),
					Phone = Convert.ToString(dataRow[2]),
					Mail = dataRow[3] != System.DBNull.Value ? Convert.ToString(dataRow[3]) : null,
					Description = dataRow[4] != System.DBNull.Value ? Convert.ToString(dataRow[4]) : null,
				});
			}

			return providers;
		}

		public List<Models.Sale> GetSales(DataTable dataTable)
		{
			var sales = new List<Models.Sale>();

			foreach (var dataRow in dataTable.Select())
			{
				sales.Add(new Models.Sale
				{
					Id = Convert.ToInt32(dataRow[0]),
					Quantity = Convert.ToInt32(dataRow[1]),
					Price = Convert.ToInt32(dataRow[2]),
					Description = dataRow[3] != System.DBNull.Value ? Convert.ToString(dataRow[3]) : null,
					Date = Convert.ToDateTime(dataRow[4]),
					IdGood = Convert.ToInt32(dataRow[5]),
					IdUser = dataRow[6] != System.DBNull.Value ? Convert.ToInt32(dataRow[6]) : nullInt,
					IdOffice = Convert.ToInt32(dataRow[7])
				});
			}

			return sales;
		}

		public List<Models.Service> GetServices(DataTable dataTable)
		{
			var services = new List<Models.Service>();

			foreach (var dataRow in dataTable.Select())
			{
				services.Add(new Models.Service
				{
					Id = Convert.ToInt32(dataRow[0]),
					Name = Convert.ToString(dataRow[1]),
					Price = Convert.ToInt32(dataRow[2]),
					Image = dataRow[3] == System.DBNull.Value ? ImageToByte(new Bitmap(_emptyGoodImage)) : (byte[])dataRow[3],
					Description = dataRow[4] != System.DBNull.Value ? Convert.ToString(dataRow[4]) : null,
					IdOffice = Convert.ToInt32(dataRow[5])
				});
			}

			return services;
		}

		public List<Models.Deal> GetDeals(DataTable dataTable)
		{
			var deal = new List<Models.Deal>();

			foreach (var dataRow in dataTable.Select())
			{
				deal.Add(new Models.Deal
				{
					Id = Convert.ToInt32(dataRow[0]),
					Name = Convert.ToString(dataRow[1]),
					Cost = Convert.ToInt32(dataRow[2]),
					Street = dataRow[3] == System.DBNull.Value ? null : dataRow[3].ToString(),
					House = dataRow[4] == System.DBNull.Value ? nullInt : Convert.ToInt32(dataRow[4]),
					Flat = dataRow[5] == System.DBNull.Value ? nullInt : Convert.ToInt32(dataRow[5]),
					CreateDate = Convert.ToDateTime(dataRow[6]),
					ProvisionDate = dataRow[7] != System.DBNull.Value ? Convert.ToDateTime(dataRow[7]) : nullDateTime,
					Description = dataRow[8] != System.DBNull.Value ? Convert.ToString(dataRow[8]) : null,
					IdStatus = dataRow[9] == System.DBNull.Value ? nullInt : Convert.ToInt32(dataRow[9]),
					IdClient = Convert.ToInt32(dataRow[10]),
					IdOffice = Convert.ToInt32(dataRow[11]),
					IdUser = dataRow[12] == System.DBNull.Value ? nullInt : Convert.ToInt32(dataRow[12]),
					IdService = dataRow[13] == System.DBNull.Value ? nullInt : Convert.ToInt32(dataRow[13]),
				});
			}

			return deal;
		}

		public List<Models.DealStatus> GetDealStatuses(DataTable dataTable)
		{
			var dealStatuses = new List<Models.DealStatus>();

			foreach (var dataRow in dataTable.Select())
			{
				dealStatuses.Add(new Models.DealStatus
				{
					Id = Convert.ToInt32(dataRow[0]),
					Name = Convert.ToString(dataRow[1]),
					Description = dataRow[2] == System.DBNull.Value ? null : dataRow[2].ToString(),
				});
			}

			return dealStatuses;
		}

		public List<Models.Audit> GetAudit(DataTable dataTable)
		{
			var audit = new List<Models.Audit>();

			foreach (var dataRow in dataTable.Select())
			{
				audit.Add(new Models.Audit
				{
					Id = Convert.ToInt32(dataRow[0]),
					Time = Convert.ToDateTime(dataRow[1]),
					Event = dataRow[2].ToString(),
					IdUser = Convert.ToInt32(dataRow[3]),
					IdOffice = dataRow[4] == System.DBNull.Value ? nullInt : Convert.ToInt32(dataRow[4])
				});
			}

			return audit;
		}
	}
}
