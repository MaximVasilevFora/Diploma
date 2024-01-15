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
	public partial class AddClient : Window
	{
		private const string _Mail = "Почта";
		private const string _Name = "Имя";
		private const string _Surname = "Фамилия";
		private const string _Patronymic = "Отчество";
		private const string _Phone = "Телефон";
		private const string _Description = "Описание";

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();
		private List<WorkingLibrary.Models.Office> _office;

		public Pages.AdminPages.Clients clientsPage;

		public AddClient()
		{
			InitializeComponent();

			_office = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();
			Office.ItemsSource = _office;

			InitWindow();
		}

		private void InitWindow()
		{
			Mail.Text = _Mail;
			UserName.Text = _Name;
			Surname.Text = _Surname;
			Patronymic.Text = _Patronymic;
			Phone.Text = _Phone;
			Description.Text = _Description;
			Office.SelectedIndex = -1;

			if (CurrentUser.user.IdUserRole != 1)
			{
				Office.SelectedItem = _office.Where(x => x.Id == CurrentUser.user.IdOffice).Last();
				Office.IsEnabled = false;
			}

			CreateDate.Text = "";
			Company.IsChecked = false;
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
			var mySqlCommand = new MySqlCommand("INSERT INTO `client` " +
				"(`surname`, `name`, `patronymic`, `phone`, `mail`, `create_date`, `company`, `description`, `id_user`, `id_office`) " +
				"VALUES (@surname, @name, @patronymic, @phone, @mail, @create_date, @company, @description, @id_user, @id_office)", dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@surname", MySqlDbType.VarChar).Value = (Surname.Text == _Surname ? null : Surname.Text);
			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = UserName.Text;
			mySqlCommand.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = (Patronymic.Text == _Patronymic ? null : Patronymic.Text);
			mySqlCommand.Parameters.Add("@phone", MySqlDbType.VarChar).Value = (Phone.Text == _Phone ? null : Phone.Text);
			mySqlCommand.Parameters.Add("@mail", MySqlDbType.VarChar).Value = Mail.Text;
			mySqlCommand.Parameters.Add("@create_date", MySqlDbType.Date).Value = CreateDate.SelectedDate.Value.ToString("yyyy-MM-dd");

			mySqlCommand.Parameters.Add("@company", MySqlDbType.Int32).Value = Company.IsChecked;

			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = Description.Text == _Description ? null : Description.Text;

			WorkingLibrary.Models.Office office = (WorkingLibrary.Models.Office)Office.SelectedValue;

			mySqlCommand.Parameters.Add("@id_user", MySqlDbType.Int32).Value = WorkingLibrary.CurrentUser.user.Id;
			mySqlCommand.Parameters.Add("@id_office", MySqlDbType.Int32).Value = office.Id;

			dataBase.OpenConnection();

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				System.Windows.MessageBox.Show("Клиент был добавлен");
			}
			else
			{
				System.Windows.MessageBox.Show("Ошибка добавления клиента");
				return;
			}

			dataBase.CloseConnection();

			WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[1], CurrentUser.user.Id, CurrentUser.user.IdOffice);

			clientsPage.InitPage();
			
			this.Close();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			clientsPage.addClient = null;
		}
	}
}
