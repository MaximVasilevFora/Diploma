using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
using WorkingLibrary.Models;
using WorkingLibrary.SqlScripts;

namespace JustCleanDiploma.Windows
{
	public partial class AuthorizationWindow : Window
	{
		private const string _LoginText = "Логин";
		private const string _PasswordText = "Пароль";

		private User _user;
		private DataWorking _dataWorking = new DataWorking();
		private RegistrationWindow _registrationWindow;
		private InvitationWindow _invitationWindow;
		private ContentWindow _contentWindow;
		private AdminWindow _adminWindow;

		public AuthorizationWindow()
		{
			InitializeComponent();
		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			var width = this.ActualWidth;
			var height = this.ActualHeight;

			if (width <= 900)
			{
				Advertisement.Visibility = Visibility.Collapsed;
				Grid.SetColumnSpan(ContentBox, 2);
			}
			else
			{
				Advertisement.Visibility = Visibility.Visible;
				Grid.SetColumnSpan(ContentBox, 1);
				Grid.SetColumn(ContentBox, 0);
			}
		}

		private void Login_LostFocus(object sender, RoutedEventArgs e)
		{
			Login.Text = Login.Text == String.Empty ? _LoginText : Login.Text;
		}

		private void Password_LostFocus(object sender, RoutedEventArgs e)
		{
			Password.Text = Password.Text == String.Empty ? _PasswordText : Password.Text;
		}

		private void Login_GotFocus(object sender, RoutedEventArgs e)
		{
			Login.Text = Login.Text == _LoginText ? "" : Login.Text;
		}

		private void Password_GotFocus(object sender, RoutedEventArgs e)
		{
			Password.Text = Password.Text == _PasswordText ? "" : Password.Text;
		}

		private void Registration_Click(object sender, RoutedEventArgs e)
		{
			if (_registrationWindow == null)
			{
				_registrationWindow = new RegistrationWindow();
				_registrationWindow.Show();
				this.Close();
			}
		}

		private void GetPassword_Click(object sender, RoutedEventArgs e)
		{
			if (Login.Text == _LoginText)
			{
				MessageBox.Show("Введите значение в поле Логин");
				return;
			}

			if (!WorkingLibrary.SqlScripts.SelectSripts.CheckUser(Login.Text))
			{
				MessageBox.Show("Пользователь с таким логином не зарегистрирован в системе. Пожалуйста, введите корректное значение в поле Логин, после чего на почту будет выслан новый пароль");
				return;
			}

			var mail = SelectSripts.SelectUserMailWithLogin(Login.Text);
			var password = PasswordWorking.CreatePassword(10);

			try
			{
				MailWorking.SendPasswordMessage(mail, Login.Text, password);
			}
			catch
			{
				MessageBox.Show("Ошибка отправки пиьсма. Возможно, указан неверный адрес электронной почты");
				return;
			}

			if (WorkingLibrary.SqlScripts.UpdateScripts.UpdateUserPasswordWithLogin(Login.Text, password))
			{
				MessageBox.Show("На почту было отправлено письмо с новым паролем");
			}
		}

		public void FillUser(DataRow row)
		{
			_user.Id = Convert.ToInt32(row[0]);

			_user.Login = Convert.ToString(row[1]);
			_user.Password = Convert.ToString(row[2]);

			if (row[3] != System.DBNull.Value)
			{
				_user.Surname = Convert.ToString(row[3]);
			}

			_user.Name = Convert.ToString(row[4]);

			if (row[5] != System.DBNull.Value)
			{
				_user.Patronymic = Convert.ToString(row[5]);
			}

			if (row[6] != System.DBNull.Value)
			{
				_user.Phone = Convert.ToString(row[6]);
			}

			_user.Mail = Convert.ToString(row[7]);

			if (row[8] == System.DBNull.Value)
			{
				var bitmap = new Bitmap(JustCleanDiploma.Properties.Resources.EmptyImageUser);
				_user.Image = _dataWorking.ImageToByte(bitmap);
			}
			else
			{
				_user.Image = (byte[])row[8];
			}

			if (row[9] != System.DBNull.Value)
			{
				_user.Description = Convert.ToString(row[9]);
			}

			_user.Ban = Convert.ToBoolean(row[10]);
			_user.InvitationCode = Convert.ToInt32(row[11]);

			if (row[12] != System.DBNull.Value)
			{
				_user.IdUserRole = Convert.ToInt32(row[12]);
			}

			if (row[13] != System.DBNull.Value)
			{
				_user.IdOffice = Convert.ToInt32(row[13]);
			}

			CurrentUser.user = _user;
		}

		private void Enter_Click(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrEmpty(Login.Text) || Login.Text == _LoginText)
			{
				MessageBox.Show("Введите значение в поле Логин");
				return;
			}

			if (String.IsNullOrEmpty(Password.Text) || Password.Text == _PasswordText)
			{
				MessageBox.Show("Введите значение в поле Пароль");
				return;
			}

			_user = new User();

			var dataTable = WorkingLibrary.SqlScripts.SelectSripts.CheckUserLogPass(Login.Text, Password.Text);

			if (dataTable.Rows.Count > 0)
			{
				if (Convert.ToBoolean(dataTable.Select()[0][10]) == true)
				{
					MessageBox.Show("Аккаунт заблокирован администратором");
					return;
				}

				MessageBox.Show("Авторизация прошла успешно");

				FillUser(dataTable.Select()[0]);

				InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[0], CurrentUser.user.Id, CurrentUser.user.IdOffice);

				if (_adminWindow == null && CurrentUser.user.IdUserRole == 1)
				{
					_adminWindow = new AdminWindow();
					_adminWindow.Show();
					this.Close();
					return;
				}

				if (_invitationWindow == null && CurrentUser.user.IdOffice == null)
				{
					_invitationWindow = new InvitationWindow();
					_invitationWindow.Show();
					this.Close();
					return;
				}

				if (_contentWindow == null && CurrentUser.user.IdUserRole == 2)
				{
					_contentWindow = new ContentWindow();
					_contentWindow.Show();
					this.Close();
					return;
				}

				if (_contentWindow == null && CurrentUser.user.IdUserRole == 3)
				{
					_contentWindow = new ContentWindow();
					_contentWindow.Show();
					this.Close();
					return;
				}
			}
			else
			{
				MessageBox.Show("Неправильный логин или пароль");
			}
		}
	}
}
