﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLibrary
{
	public class JustCleanDataBase
	{
		public MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=miramax");

		public void OpenConnection()
		{
			if (mySqlConnection.State == System.Data.ConnectionState.Closed)
			{
				mySqlConnection.Open();
			}
		}

		public void CloseConnection()
		{
			if (mySqlConnection.State == System.Data.ConnectionState.Open)
			{
				mySqlConnection.Close();
			}
		}

		public MySqlConnection GetConnection()
		{
			return mySqlConnection;
		}
	}
}
