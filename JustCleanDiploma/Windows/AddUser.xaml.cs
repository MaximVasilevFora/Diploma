using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

namespace JustCleanDiploma.Windows
{
	public partial class AddUser : Window
	{
		private const string _LoginText = "Логин";
		private const string _Mail = "Почта";
		private const string _Name = "Имя";
		private const string _Surname = "Фамилия";
		private const string _Patronymic = "Отчество";
		private const string _Phone = "Телефон";
		private const string _Description = "Описание";
		private const string _Password = "Пароль";
		private const string _Role = "Роль";
		private const string _Ban = "Бан";
		private const string _InviteCode = "Пригласительный код";

		private System.Windows.Forms.OpenFileDialog _openFileDialog = new System.Windows.Forms.OpenFileDialog();
		private byte[] _profilImage;
		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();
		private List<WorkingLibrary.Models.Office> _office;

		public Pages.AdminPages.Users usersPage;

		public AddUser()
		{
			InitializeComponent();

			_openFileDialog.Filter = "Png files(*.png)|*.png|Jpg files(*.jpg)|*.jpg|Jpeg files(*.jpeg)|*.jpeg";

			Role.ItemsSource = _dataWorking.GetUserRoles(WorkingLibrary.SqlScripts.SelectSripts.SelectUserRoles()).ToList();
			_office = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();

			var bitmap = new Bitmap(JustCleanDiploma.Properties.Resources.EmptyImageUser);
			ProfilImage.Source = ConvertBitmapToBitmapSource(bitmap);

			_profilImage = _dataWorking.ImageToByte(bitmap);

			InviteCode.Text = Convert.ToString(_dataWorking.GetInvitationCode());
		}

		private void InitWindow()
		{
			Login.Text = _LoginText;
			Password.Text = _Password;
			InviteCode.Text = _InviteCode;
			Mail.Text = _Mail;
			UserName.Text = _Name;
			Surname.Text = _Surname;
			Patronymic.Text = _Patronymic;
			Phone.Text = _Phone;
			Description.Text = _Description;
			Role.SelectedIndex = -1;
			Office.SelectedIndex = -1;
		}

		private BitmapSource ConvertBitmapToBitmapSource(System.Drawing.Bitmap bitmap)
		{
			var bitmapData = bitmap.LockBits(
				new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
				System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

			var bitmapSource = BitmapSource.Create(
				bitmapData.Width, bitmapData.Height,
				bitmap.HorizontalResolution, bitmap.VerticalResolution,
				PixelFormats.Bgr24, null,
				bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

			bitmap.UnlockBits(bitmapData);

			return bitmapSource;
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrEmpty(Login.Text) || Login.Text == _LoginText)
			{
				System.Windows.MessageBox.Show("Введите значение в поле Логин");
				return;
			}

			if (String.IsNullOrEmpty(Password.Text) || Password.Text == _Password)
			{
				System.Windows.MessageBox.Show("Введите значение в поле Пароль");
				return;
			}

			if (Password.Text.Count() < 5)
			{
				System.Windows.MessageBox.Show("Пароль должен содержать более 4 символов");
				return;
			}

			if (String.IsNullOrEmpty(InviteCode.Text) || InviteCode.Text == _InviteCode)
			{
				System.Windows.MessageBox.Show("Введите значение в поле Пригласительный код");
				return;
			}

			if (InviteCode.Text.Count() < 6)
			{
				System.Windows.MessageBox.Show("Пригласительный код должен содержать 6 символов");
				return;
			}

			if (WorkingLibrary.SqlScripts.SelectSripts.CheckInviteCode(InviteCode.Text))
			{
				System.Windows.MessageBox.Show("Пользователь с таким Пригласительным кодом уже существует");
				return;
			}

			if (String.IsNullOrEmpty(Mail.Text) || Mail.Text == _Mail)
			{
				System.Windows.MessageBox.Show("Ввведите значение в поле Почта");
				return;
			}

			if (!WorkingLibrary.MailWorking.CheckMail(Mail.Text))
			{
				System.Windows.MessageBox.Show("Введите корректный почтовый адрес");
				return;
			}

			if (String.IsNullOrEmpty(UserName.Text) || UserName.Text == _Name)
			{
				System.Windows.MessageBox.Show("Ввведите значение в поле Имя");
				return;
			}

			if (WorkingLibrary.SqlScripts.SelectSripts.CheckUser(Login.Text))
			{
				System.Windows.MessageBox.Show("Пользователь с таким логином уже существует");
				return;
			}

			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("INSERT INTO `user` " +
				"(`surname`, `name`, `patronymic`, `login`, `password`, `phone`, `mail`, `image`, `ban`, `description`, `invitation_code`, `id_user_role`, `id_office`) " +
				"VALUES (@surname, @name, @patronymic, @login, @password, @phone, @mail, @image, @ban, @description, @invitation_code, @id_user_role, @id_office)", dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@surname", MySqlDbType.VarChar).Value = (Surname.Text == _Surname ? null : Surname.Text);
			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = UserName.Text;
			mySqlCommand.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = (Patronymic.Text == _Patronymic ? null : Patronymic.Text);
			mySqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = Login.Text;
			mySqlCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = Password.Text;
			mySqlCommand.Parameters.Add("@phone", MySqlDbType.VarChar).Value = (Phone.Text == _Phone ? null : Phone.Text);
			mySqlCommand.Parameters.Add("@mail", MySqlDbType.VarChar).Value = Mail.Text;

			mySqlCommand.Parameters.Add("@image", MySqlDbType.MediumBlob).Value = _profilImage;

			mySqlCommand.Parameters.Add("@ban", MySqlDbType.Int32).Value = Ban.IsChecked;

			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = Description.Text == _Description ? null : Description.Text;
			mySqlCommand.Parameters.Add("@invitation_code", MySqlDbType.Int32).Value = Convert.ToInt32(InviteCode.Text);

			if (Role.SelectedItem == null)
			{
				mySqlCommand.Parameters.Add("@id_user_role", MySqlDbType.Int32).Value = null;
				mySqlCommand.Parameters.Add("@id_office", MySqlDbType.Int32).Value = null;
			}
			else
			{
				WorkingLibrary.Models.UserRole userRole = (WorkingLibrary.Models.UserRole)Role.SelectedValue;
				WorkingLibrary.Models.Office office = (WorkingLibrary.Models.Office)Office.SelectedValue;

				mySqlCommand.Parameters.Add("@id_user_role", MySqlDbType.Int32).Value = userRole.Id;
				mySqlCommand.Parameters.Add("@id_office", MySqlDbType.Int32).Value = office.Id;
			}

			dataBase.OpenConnection();

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				System.Windows.MessageBox.Show("Пользоваетель был добавлен");
			}
			else
			{
				System.Windows.MessageBox.Show("Ошибка добавления пользователя");
				return;
			}

			dataBase.CloseConnection();

			WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[7], CurrentUser.user.Id, CurrentUser.user.IdOffice);

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

		private void ChangeProfilImage()
		{
			if (_openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				var bitmap = new BitmapImage(new Uri(_openFileDialog.FileName));
				ProfilImage.Source = bitmap;

				_profilImage = _dataWorking.BitmapImageInArray(bitmap);
			}
		}

		private void ProfilImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ChangeProfilImage();
		}

		private void ChangeImage_Click(object sender, RoutedEventArgs e)
		{
			ChangeProfilImage();
		}

		private void InviteCode_GotFocus(object sender, RoutedEventArgs e)
		{
			InviteCode.Text = InviteCode.Text == _InviteCode ? "" : InviteCode.Text;
		}

		private void InviteCode_LostFocus(object sender, RoutedEventArgs e)
		{
			InviteCode.Text = InviteCode.Text == String.Empty ? _InviteCode : InviteCode.Text;
		}

		private void InviteCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
		}

		private void Login_GotFocus(object sender, RoutedEventArgs e)
		{
			Login.Text = Login.Text == _LoginText ? "" : Login.Text;
		}

		private void Login_LostFocus(object sender, RoutedEventArgs e)
		{
			Login.Text = Login.Text == String.Empty ? _LoginText : Login.Text;
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

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			usersPage.addUser = null;

			usersPage.InitPage();
		}

		private void Password_GotFocus(object sender, RoutedEventArgs e)
		{
			Password.Text = Password.Text == _Password ? "" : Password.Text;
		}

		private void Password_LostFocus(object sender, RoutedEventArgs e)
		{
			Password.Text = Password.Text == String.Empty ? _Password : Password.Text;
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
	}
}
