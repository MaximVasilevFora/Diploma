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
	public partial class AddSale : Window
	{
		private const string _Quantity = "Количество";
		private const string _Price = "Цена";
		private const string _Description = "Описание";

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();
		private List<WorkingLibrary.Models.Office> _office;
		private List<WorkingLibrary.Models.User> _user;
		private List<WorkingLibrary.Models.Good> _good;

		public Pages.AdminPages.Sales sales;

		public AddSale()
		{
			InitializeComponent();

			_office = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();
			_user = _dataWorking.GetUsers(WorkingLibrary.SqlScripts.SelectSripts.SelectUsers()).ToList();
			_good = _dataWorking.GetGoods(WorkingLibrary.SqlScripts.SelectSripts.SelectGoods()).ToList();

			InitWindow();
		}

		private void InitWindow()
		{
			Office.ItemsSource = _office;

			if (CurrentUser.user.IdUserRole != 1)
			{
				Office.SelectedItem = _office.Where(x => x.Id == CurrentUser.user.IdOffice).Last();
				Office.IsEnabled = false;

				UserCombo.ItemsSource = _user.Where(x => x.IdOffice == CurrentUser.user.IdOffice);
				Good.ItemsSource = _good.Where(x => x.IdOffice == CurrentUser.user.IdOffice);
			}
			else
			{
				UserCombo.ItemsSource = _user;
				Good.ItemsSource = _good;
				Office.SelectedIndex = -1;
			}
			
			UserCombo.SelectedIndex = -1;
			Good.SelectedIndex = -1;
			Quantity.Text = _Quantity;
			Price.Text = _Price;
			SaleDate.Text = "";
			Description.Text = _Description;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			sales.addSale = null;
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
			var mySqlCommand = new MySqlCommand("INSERT INTO `sale` " +
				"(`quantity`, `price`, `description`, `date`, `id_good`, `id_user`, `id_office`) " +
				"VALUES (@quantity, @price, @description, @date, @id_good, @id_user, @id_office)", dataBase.GetConnection());

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

			dataBase.OpenConnection();

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				System.Windows.MessageBox.Show("Продажа была успешно зафиксирована");
			}
			else
			{
				System.Windows.MessageBox.Show("Ошибка фиксирования продажи товара");
				return;
			}

			WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[5], CurrentUser.user.Id, CurrentUser.user.IdOffice);

			dataBase.CloseConnection();

			sales.InitPage();

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
	}
}
