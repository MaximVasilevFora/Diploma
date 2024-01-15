using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLibrary.SqlScripts
{
	public static class SelectSripts
	{
		public static bool CheckUser(string userLogin)
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @userLogin", db.GetConnection());
			sqlCommands.Parameters.Add("@userLogin", MySqlDbType.VarChar).Value = userLogin;

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			if (dataTable.Rows.Count > 0)
			{
				return true;
			}

			return false;
		}

		public static bool CheckInviteCode(string inviteCode)
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `user` WHERE `invitation_code` = @invitation_code", db.GetConnection());
			sqlCommands.Parameters.Add("@invitation_code", MySqlDbType.Int32).Value = Convert.ToInt32(inviteCode);

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			if (dataTable.Rows.Count > 0)
			{
				return true;
			}

			return false;
		}

		public static DataTable SelectUserRoles()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `user_role`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}

		public static DataTable SelectOffices()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `office`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}

		public static DataTable SelectUsers()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `user`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}

		public static DataTable SelectClients()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `client`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}

		public static DataTable SelectGoods()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `good`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}

		public static DataTable SelectProviders()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `provider`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}

		public static DataTable SelectSales()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `sale`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}

		public static DataTable SelectServices()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `service`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}

		public static DataTable SelectDeals()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `deal`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}

		public static DataTable SelectDealStatuses()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `deal_status`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}

		public static DataTable SelectAudit()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `audit`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}

		public static int SelectLastUserId()
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT MAX(id) FROM `user`", db.GetConnection());

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			var id = 0;

			if (dataTable.Rows.Count > 0)
			{
				id = Convert.ToInt32(dataTable.Select()[0][0]);
			}

			return id;
		}

		public static string SelectUserRoleNameWithId(int? id)
		{
			if (id == null)
			{
				return null;
			}

			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT name FROM `user_role` WHERE `id` = @id", db.GetConnection());

			sqlCommands.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			var responce = "";

			if (dataTable.Rows.Count > 0)
			{
				responce = Convert.ToString(dataTable.Select()[0][0]);
			}

			return responce;
		}

		public static string SelectOfficeNameWitId(int? id)
		{
			if (id == null)
			{
				return null;
			}

			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT name FROM `office` WHERE `id` = @id", db.GetConnection());

			sqlCommands.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			var responce = "";

			if (dataTable.Rows.Count > 0)
			{
				responce = Convert.ToString(dataTable.Select()[0][0]);
			}

			return responce;
		}

		public static string SelectUserMailWithId(int? id)
		{
			if (id == null)
			{
				return null;
			}

			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT mail FROM `user` WHERE `id` = @id", db.GetConnection());

			sqlCommands.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			var responce = "";

			if (dataTable.Rows.Count > 0)
			{
				responce = Convert.ToString(dataTable.Select()[0][0]);
			}

			return responce;
		}

		public static string SelectGoodWithId(int? id)
		{
			if (id == null)
			{
				return null;
			}

			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT name FROM `good` WHERE `id` = @id", db.GetConnection());

			sqlCommands.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			var responce = "";

			if (dataTable.Rows.Count > 0)
			{
				responce = Convert.ToString(dataTable.Select()[0][0]);
			}

			return responce;
		}

		public static string SelectUserMailWithLogin(string login)
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT mail FROM `user` WHERE `login` = @login", db.GetConnection());

			sqlCommands.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			var responce = "";

			if (dataTable.Rows.Count > 0)
			{
				responce = Convert.ToString(dataTable.Select()[0][0]);
			}

			return responce;
		}

		public static string SelectClientPhoneWithId(int id)
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT phone FROM `client` WHERE `id` = @id", db.GetConnection());

			sqlCommands.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			var responce = "";

			if (dataTable.Rows.Count > 0)
			{
				responce = Convert.ToString(dataTable.Select()[0][0]);
			}

			return responce;
		}

		public static string SelectServiceNameWithId(int? id)
		{
			if (id == null)
			{
				return null;
			}

			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT name FROM `service` WHERE `id` = @id", db.GetConnection());

			sqlCommands.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			var responce = "";

			if (dataTable.Rows.Count > 0)
			{
				responce = Convert.ToString(dataTable.Select()[0][0]);
			}

			return responce;
		}

		public static DataTable CheckUserLogPass(string login, string password)
		{
			var db = new JustCleanDataBase();

			var dataTable = new DataTable();

			var adapter = new MySqlDataAdapter();

			var sqlCommands = new MySqlCommand("SELECT * FROM `user`" +
				"WHERE `login` = @userLogin AND `password` = @userPassword",
				db.GetConnection());

			sqlCommands.Parameters.Add("@userLogin", MySqlDbType.VarChar).Value = login;
			sqlCommands.Parameters.Add("@userPassword", MySqlDbType.VarChar).Value = password;

			adapter.SelectCommand = sqlCommands;
			adapter.Fill(dataTable);

			return dataTable;
		}
	}
}
