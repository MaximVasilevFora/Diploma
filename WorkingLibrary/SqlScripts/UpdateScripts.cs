using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLibrary.SqlScripts
{
	public class UpdateScripts
	{
		public static bool UpdateOffice(string name, string region, string city, string street, int? house, string description, int id)
		{
			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("UPDATE `office` " +
				"SET `name` = @name, " +
				"`region` = @region, " +
				"`city` = @city, " +
				"`street` = @street, " +
				"`house` = @house, " +
				"`description ` = @description, " +
				"WHERE `id` = @id",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
			mySqlCommand.Parameters.Add("@region", MySqlDbType.VarChar).Value = region;
			mySqlCommand.Parameters.Add("@city", MySqlDbType.VarChar).Value = city;
			mySqlCommand.Parameters.Add("@street", MySqlDbType.VarChar).Value = street;
			mySqlCommand.Parameters.Add("@house", MySqlDbType.Int32).Value = house;
			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			dataBase.OpenConnection();

			var responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool UpdateProvider(string name, string phone, string mail, string description, int id)
		{
			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("UPDATE `provider` " +
				"SET `name` = @name, " +
				"`phone` = @phone, " +
				"`mail` = @mail, " +
				"`description` = @description " +
				"WHERE `id` = @id",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
			mySqlCommand.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
			mySqlCommand.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;
			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			dataBase.OpenConnection();

			var responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool UpdateUserWithCode(int idRole, int idOffice, int code)
		{
			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("UPDATE `user` " +
				"SET `id_user_role` = @id_user_role, " +
				"`id_office` = @id_office " +
				"WHERE `invitation_code` = @invitation_code",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id_user_role", MySqlDbType.VarChar).Value = idRole;
			mySqlCommand.Parameters.Add("@id_office", MySqlDbType.VarChar).Value = idOffice;
			mySqlCommand.Parameters.Add("@invitation_code", MySqlDbType.Int32).Value = code;

			dataBase.OpenConnection();

			var responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool UpdateUserPasswordWithLogin(string login, string password)
		{
			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("UPDATE `user` " +
				"SET `password` = @password " +
				"WHERE `login` = @login",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
			mySqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;

			dataBase.OpenConnection();

			var responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool UpdateDealStatus(int id, int idStatus)
		{
			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("UPDATE `deal` " +
				"SET `id_status` = @id_status " +
				"WHERE `id` = @id",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id_status", MySqlDbType.Int32).Value = idStatus;
			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			dataBase.OpenConnection();

			var responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}
	}
}
