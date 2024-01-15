using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkingLibrary;

namespace JustCleanDiploma.Windows
{
	public partial class EditSale : Window
	{
		private const string _Quantity = "Количество";
		private const string _Price = "Цена";
		private const string _Description = "Описание";

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();
		private WorkingLibrary.Models.Sale _sale;
		private List<WorkingLibrary.Models.Office> _offices;
		private List<WorkingLibrary.Models.User> _users;
		private List<WorkingLibrary.Models.Good> _goods;

		public Pages.AdminPages.Sales sales;

		public EditSale(object sender)
		{
			InitializeComponent();

			_offices = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();
			_users = _dataWorking.GetUsers(WorkingLibrary.SqlScripts.SelectSripts.SelectUsers()).ToList();
			_goods = _dataWorking.GetGoods(WorkingLibrary.SqlScripts.SelectSripts.SelectGoods()).ToList();

			_sale = (sender as Button).DataContext as WorkingLibrary.Models.Sale;

			InitWindow();
		}

		private void InitWindow()
		{
			Office.ItemsSource = _offices;
			Office.SelectedItem = _offices.Where(x => x.Id == _sale.IdOffice).Last();

			if (CurrentUser.user.IdUserRole != 1)
			{
				Office.IsEnabled = false;

				UserCombo.ItemsSource = _users.Where(x => x.IdOffice == CurrentUser.user.IdOffice);
				Good.ItemsSource = _goods.Where(x => x.IdOffice == CurrentUser.user.IdOffice);
			}
			else
			{
				UserCombo.ItemsSource = _users;
				Good.ItemsSource = _goods;
			}

			if (_sale.IdUser != null)
			{
				UserCombo.SelectedItem = _users.Where(x => x.Id == _sale.IdUser).Last();
			}
			
			Good.SelectedItem = _goods.Where(x => x.Id == _sale.IdGood).Last();

			Quantity.Text = _sale.Quantity.ToString();
			Price.Text = _sale.Price.ToString();
			SaleDate.SelectedDate = _sale.Date;

			if (_sale.Description != null)
			{
				Description.Text = _sale.Description.ToString();
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			sales.editSale = null;
			sales.InitPage();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(Quantity.Text) || Quantity.Text == _Quantity)
			{
				MessageBox.Show("Введите значение в поле Количество");
				return;
			}

			if (Convert.ToInt32(Quantity.Text) < 1)
			{
				MessageBox.Show("Введите корректное значение в поле Количество");
				return;
			}

			if (string.IsNullOrEmpty(Price.Text) || Price.Text == _Price)
			{
				MessageBox.Show("Введите значение в поле Цена");
				return;
			}

			if (Office.SelectedItem == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Офис");
				return;
			}

			if (Good.SelectedItem == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Товар");
				return;
			}

			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("UPDATE `sale` " +
				"SET `quantity` = @quantity, " +
				"`price` = @price, " +
				"`description` = @description, " +
				"`date` = @date, " +
				"`id_good` = @id_good, " +
				"`id_user` = @id_user, " +
				"`id_office` = @id_office " +
				"WHERE `id` = @id",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@quantity", MySqlDbType.Int32).Value = Quantity.Text;
			mySqlCommand.Parameters.Add("@price", MySqlDbType.Int32).Value = Price.Text;
			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = (Description.Text == _Description ? null : Description.Text);

			if (SaleDate.SelectedDate == null)
			{
				mySqlCommand.Parameters.Add("@date", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
			}
			else
			{
				mySqlCommand.Parameters.Add("@date", MySqlDbType.DateTime).Value = SaleDate.SelectedDate.Value.ToString("yyyy-MM-dd hh:mm:ss");
			}

			WorkingLibrary.Models.Good good = (WorkingLibrary.Models.Good)Good.SelectedValue;
			mySqlCommand.Parameters.Add("@id_good", MySqlDbType.Int32).Value = good.Id;

			if (UserCombo.SelectedItem == null)
			{
				mySqlCommand.Parameters.Add("@id_user", MySqlDbType.Int32).Value = null;
			}
			else
			{
				WorkingLibrary.Models.User user = (WorkingLibrary.Models.User)UserCombo.SelectedValue;
				mySqlCommand.Parameters.Add("@id_user", MySqlDbType.Int32).Value = user.Id;
			}

			WorkingLibrary.Models.Office office = (WorkingLibrary.Models.Office)Office.SelectedValue;
			mySqlCommand.Parameters.Add("@id_office", MySqlDbType.Int32).Value = office.Id;

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = _sale.Id;

			dataBase.OpenConnection();

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				System.Windows.MessageBox.Show("Данные о продаже успешно изменены");
			}
			else
			{
				System.Windows.MessageBox.Show("Ошибка изменения сведений о продаже");
				return;
			}

			dataBase.CloseConnection();

			WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[17], CurrentUser.user.Id, CurrentUser.user.IdOffice);

			this.Close();
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			var result = System.Windows.MessageBox.Show("Вы уверены, что хотите отменить изменения?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.No)
			{
				return;
			}

			InitWindow();
		}

		private void Quantity_GotFocus(object sender, RoutedEventArgs e)
		{
			Quantity.Text = Quantity.Text == _Quantity ? "" : Quantity.Text;
		}

		private void Quantity_LostFocus(object sender, RoutedEventArgs e)
		{
			Quantity.Text = Quantity.Text == String.Empty ? _Quantity : Quantity.Text;
		}

		private void Price_GotFocus(object sender, RoutedEventArgs e)
		{
			Price.Text = Price.Text == _Price ? "" : Price.Text;
		}

		private void Price_LostFocus(object sender, RoutedEventArgs e)
		{
			Price.Text = Price.Text == String.Empty ? _Price : Price.Text;
		}

		private bool SimbolIsDigit(TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				return true;
			}

			return false;
		}

		private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = SimbolIsDigit(e);
		}

		private void Quantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = SimbolIsDigit(e);
		}

		private void Description_GotFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == _Description ? "" : Description.Text;
		}

		private void Description_LostFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == String.Empty ? _Description : Description.Text;
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			var result = System.Windows.MessageBox.Show("Вы уверены, что хотите удалить запись о продаже?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.No)
			{
				return;
			}

			if (WorkingLibrary.SqlScripts.DeleteScripts.DeleteSale(_sale.Id))
			{
				System.Windows.MessageBox.Show("Запись о продаже была успешно удалена");

				WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[18], CurrentUser.user.Id, CurrentUser.user.IdOffice);

				this.Close();
			}
		}
	}
}
