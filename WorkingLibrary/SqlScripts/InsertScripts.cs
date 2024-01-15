using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLibrary.SqlScripts
{
	public static class InsertScripts
	{
		public static bool RegUser(string name, string login, string password, string mail, int ban, int code)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("INSERT INTO `user` " +
				"(`name`, `login`, `password`, `mail`, `ban`, `invitation_code`) " +
				"VALUES (@name, @login, @password, @mail, @ban, @invitation_code)",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
			mySqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
			mySqlCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
			mySqlCommand.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;
			mySqlCommand.Parameters.Add("@ban", MySqlDbType.Int16).Value = ban;
			mySqlCommand.Parameters.Add("@invitation_code", MySqlDbType.Int32).Value = code;

			dataBase.OpenConnection();

			bool complete = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				complete = true;
			}

			dataBase.CloseConnection();

			return complete;
		}

		public static bool InsertActionToAudit(DateTime time, string someEvent, int idUser, int? idOffice)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("INSERT INTO `audit` " +
				"(`time`, `event`, `id_user`, id_office) " +
				"VALUES (@time, @event, @id_user, @id_office)",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@time", MySqlDbType.VarChar).Value = time.ToString("yyyy-MM-dd hh:mm:ss");
			mySqlCommand.Parameters.Add("@event", MySqlDbType.VarChar).Value = someEvent;
			mySqlCommand.Parameters.Add("@id_user", MySqlDbType.VarChar).Value = idUser;
			mySqlCommand.Parameters.Add("@id_office", MySqlDbType.VarChar).Value = idOffice;

			dataBase.OpenConnection();

			bool responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool InsertSale(int quantity, int price, string description, DateTime date, int idGood, int? idUser, int idOffice)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("INSERT INTO `sale` " +
				"(`quantity`, `price`, `description`, `date`, `id_good`, `id_user`, `id_office`) " +
				"VALUES (@quantity, @price, @description, @date, @id_good, @id_user, @id_office)",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
			mySqlCommand.Parameters.Add("@price", MySqlDbType.Int32).Value = price;
			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
			mySqlCommand.Parameters.Add("@date", MySqlDbType.DateTime).Value = date.ToString("yyyy-MM-dd hh:mm:ss");
			mySqlCommand.Parameters.Add("@id_good", MySqlDbType.VarChar).Value = idGood;
			mySqlCommand.Parameters.Add("@id_user", MySqlDbType.VarChar).Value = idUser;
			mySqlCommand.Parameters.Add("@id_office", MySqlDbType.VarChar).Value = idOffice;

			dataBase.OpenConnection();

			bool responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool InsertOffice(string name, string region, string city, string street, int? house, string description)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("INSERT INTO `office` " +
				"(`name`, `region`, `city`, `street`, `house`, `description`) " +
				"VALUES (@name, @region, @city, @street, @house, @description)",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@name", MySqlDbType.Int32).Value = name;
			mySqlCommand.Parameters.Add("@region", MySqlDbType.Int32).Value = region;
			mySqlCommand.Parameters.Add("@city", MySqlDbType.VarChar).Value = city;
			mySqlCommand.Parameters.Add("@street", MySqlDbType.VarChar).Value = street;
			mySqlCommand.Parameters.Add("@house", MySqlDbType.Int32).Value = house;
			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;

			dataBase.OpenConnection();

			bool responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool InsertProvider(string name, string phone, string mail, string description)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("INSERT INTO `provider` " +
				"(`name`, `phone`, `mail`, `description`) " +
				"VALUES (@name, @phone, @mail, @description)",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
			mySqlCommand.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
			mySqlCommand.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;
			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;

			dataBase.OpenConnection();

			bool responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}
	}
}
