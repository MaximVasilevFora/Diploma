using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLibrary.SqlScripts
{
	public class DeleteScripts
	{
		public static bool DeleteUser(int id)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("DELETE FROM `user` WHERE `id` = @id", dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			dataBase.OpenConnection();

			bool responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool DeleteOffice(int id)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("DELETE FROM `office` WHERE `id` = @id", dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			dataBase.OpenConnection();

			bool responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool DeleteClient(int id)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("DELETE FROM `client` WHERE `id` = @id", dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			dataBase.OpenConnection();

			bool responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool DeleteSale(int id)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("DELETE FROM `sale` WHERE `id` = @id", dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			dataBase.OpenConnection();

			bool responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool DeleteGood(int id)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("DELETE FROM `good` WHERE `id` = @id", dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			dataBase.OpenConnection();

			bool responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool DeleteService(int id)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("DELETE FROM `service` WHERE `id` = @id", dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			dataBase.OpenConnection();

			bool responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool DeleteProvider(int id)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("DELETE FROM `provider` WHERE `id` = @id", dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			dataBase.OpenConnection();

			bool responce = false;

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				responce = true;
			}

			dataBase.CloseConnection();

			return responce;
		}

		public static bool DeleteDeal(int id)
		{
			var dataBase = new JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("DELETE FROM `deal` WHERE `id` = @id", dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

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
