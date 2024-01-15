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
	public partial class EditClient : Window
	{
		private const string _Mail = "Почта";
		private const string _Name = "Имя";
		private const string _Surname = "Фамилия";
		private const string _Patronymic = "Отчество";
		private const string _Phone = "Телефон";
		private const string _Description = "Описание";

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();
		private WorkingLibrary.Models.Client _client;
		private List<WorkingLibrary.Models.Office> _offices;
		private List<WorkingLibrary.Models.User> _users;

		public Pages.AdminPages.Clients clientsPage;

		public EditClient(object sender)
		{
			InitializeComponent();

			_offices = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();
			_users = _dataWorking.GetUsers(WorkingLibrary.SqlScripts.SelectSripts.SelectUsers()).ToList();

			_client = (sender as Button).DataContext as WorkingLibrary.Models.Client;

			InitWindow();
		}

		private void InitWindow()
		{
			Office.ItemsSource = _offices;
			Office.SelectedItem = _offices.Where(x => x.Id == _client.IdOffice).Last();

			if (CurrentUser.user.IdUserRole != 1)
			{
				Office.IsEnabled = false;
				userId.ItemsSource = _users.Where(x => x.IdOffice == CurrentUser.user.IdOffice);
			}
			else
			{
				userId.ItemsSource = _users;
			}

			if (_client.IdUser != null)
			{
				userId.SelectedItem = _users.Where(x => x.Id == _client.IdUser).Last();
			}
			
			CreateDate.Text = Convert.ToString(_client.CreateDate);

			if (_client.Mail != null)
			{
				Mail.Text = Convert.ToString(_client.Mail);
			}
			
			UserName.Text = _client.Name;

			if (_client.Surname != null)
			{
				Surname.Text = _client.Surname;
			}

			if (_client.Patronymic != null)
			{
				Patronymic.Text = _client.Patronymic;
			}
			
			Phone.Text = _client.Phone;

			if (_client.Description != null)
			{
				Description.Text = _client.Description;
			}

			Company.IsChecked = _client.Company;
		}

		private void Mail_GotFocus(object sender, RoutedEventArgs e)
		{
			Mail.Text = Mail.Text == _Mail ? "" : Mail.Text;
		}

		private void Mail_LostFocus(object sender, RoutedEventArgs e)
		{
			Mail.Text = Mail.Text == String.Empty ? _Mail : Mail.Text;
		}

		private void Name_GotFocus(object sender, RoutedEventArgs e)
		{
			UserName.Text = UserName.Text == _Name ? "" : UserName.Text;
		}

		private void Name_LostFocus(object sender, RoutedEventArgs e)
		{
			UserName.Text = UserName.Text == String.Empty ? _Name : UserName.Text;
		}

		private void Surname_GotFocus(object sender, RoutedEventArgs e)
		{
			Surname.Text = Surname.Text == _Surname ? "" : Surname.Text;
		}

		private void Surname_LostFocus(object sender, RoutedEventArgs e)
		{
			Surname.Text = Surname.Text == String.Empty ? _Surname : Surname.Text;
		}

		private void Patronymic_GotFocus(object sender, RoutedEventArgs e)
		{
			Patronymic.Text = Patronymic.Text == _Patronymic ? "" : Patronymic.Text;
		}

		private void Patronymic_LostFocus(object sender, RoutedEventArgs e)
		{
			Patronymic.Text = Patronymic.Text == String.Empty ? _Patronymic : Patronymic.Text;
		}

		private void Phone_GotFocus(object sender, RoutedEventArgs e)
		{
			Phone.Text = Phone.Text == _Phone ? "" : Phone.Text;
		}

		private void Phone_LostFocus(object sender, RoutedEventArgs e)
		{
			Phone.Text = Phone.Text == String.Empty ? _Phone : Phone.Text;
		}

		private void Description_GotFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == _Description ? "" : Description.Text;
		}

		private void Description_LostFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == String.Empty ? _Description : Description.Text;
		}

		private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
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

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrEmpty(Mail.Text) || Mail.Text == _Mail)
			{
				System.Windows.MessageBox.Show("Ввведите значение в поле Почта");
				return;
			}

			if (!WorkingLibrary.MailWorking.CheckMail(Mail.Text) && Mail.Text != _Mail)
			{
				System.Windows.MessageBox.Show("Введите корректный почтовый адрес");
				return;
			}

			if (String.IsNullOrEmpty(UserName.Text) || UserName.Text == _Name)
			{
				System.Windows.MessageBox.Show("Ввведите значение в поле Имя");
				return;
			}

			if (CreateDate.SelectedDate == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Дата добавления");
				return;
			}

			if (Phone.Text == _Phone)
			{
				System.Windows.MessageBox.Show("Введите значение в поле Телефон");
				return;
			}

			if (Phone.Text.Length < 10)
			{
				System.Windows.MessageBox.Show("Введите корректный номер телефона");
				return;
			}

			if (Office.SelectedItem == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Офис");
				return;
			}

			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("UPDATE `client` " +
				"SET `surname` = @surname, " +
				"`name` = @name, " +
				"`patronymic` = @patronymic, " +
				"`phone` = @phone, " +
				"`mail` = @mail, " +
				"`create_date` = @create_date, " +
				"`company` = @company, " +
				"`description` = @description, " +
				"`id_user` = @id_user, " +
				"`id_office` = @id_office " +
				"WHERE `id` = @id",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = _client.Id;
			mySqlCommand.Parameters.Add("@surname", MySqlDbType.VarChar).Value = Surname.Text == _Surname ? null : Surname.Text;
			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = UserName.Text;
			mySqlCommand.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = Patronymic.Text == _Patronymic ? null : Patronymic.Text;
			mySqlCommand.Parameters.Add("@phone", MySqlDbType.VarChar).Value = Phone.Text;
			mySqlCommand.Parameters.Add("@mail", MySqlDbType.VarChar).Value = Mail.Text == _Mail ? null : Mail.Text;

			mySqlCommand.Parameters.Add("@create_date", MySqlDbType.VarChar).Value = CreateDate.SelectedDate.Value.ToString("yyyy-MM-dd");

			mySqlCommand.Parameters.Add("@company", MySqlDbType.Int32).Value = Company.IsChecked;
			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = Description.Text == _Description ? null : Description.Text;

			if (userId.SelectedIndex == -1)
			{
				mySqlCommand.Parameters.Add("@id_user", MySqlDbType.Int32).Value = null;
			}
			else
			{
				WorkingLibrary.Models.User user = (WorkingLibrary.Models.User)userId.SelectedValue;
				mySqlCommand.Parameters.Add("@id_user", MySqlDbType.Int32).Value = user.Id;
			}

			WorkingLibrary.Models.Office office = (WorkingLibrary.Models.Office)Office.SelectedValue;
			mySqlCommand.Parameters.Add("@id_office", MySqlDbType.Int32).Value = office.Id;

			dataBase.OpenConnection();

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				System.Windows.MessageBox.Show("Данные были изменены");
			}
			else
			{
				System.Windows.MessageBox.Show("Ошибка изменения данных");
				return;
			}

			dataBase.CloseConnection();

			WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[9], CurrentUser.user.Id, CurrentUser.user.IdOffice);

			this.Close();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			clientsPage.editClient = null;
			clientsPage.InitPage();
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			var result = System.Windows.MessageBox.Show("Вы уверены, что хотите удалить клиента?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.No)
			{
				return;
			}

			if (WorkingLibrary.SqlScripts.DeleteScripts.DeleteClient(_client.Id))
			{
				System.Windows.MessageBox.Show("Клиент был успешно удален");

				WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[10], CurrentUser.user.Id, CurrentUser.user.IdOffice);

				this.Close();
			}
		}
	}
}
