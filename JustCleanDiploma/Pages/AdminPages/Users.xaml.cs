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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkingLibrary;

namespace JustCleanDiploma.Pages.AdminPages
{
	public partial class Users : Page
	{
		private List<WorkingLibrary.Models.User> _users;
		private List<WorkingLibrary.Models.Office> _offices;
		private DataWorking _dataWorking = new DataWorking();

		public Windows.EditUser editUser;
		public Windows.AddUser addUser;
		public Windows.AddUserWithInventation addUserWithInventation;

		private const string _UserMail = "Почта сотрудника";
		private const string _AllOffices = "Все офисы";

		private string _mail;
		private int _lastIdOffice;

		public Users()
		{
			InitializeComponent();

			InitPage();
		}

		public void InitPage()
		{
			if (CurrentUser.user.IdUserRole == 3)
			{
				AddUser.IsEnabled = false;
				AddUserWithCode.IsEnabled = false;
				editUser.IsEnabled = false;
			}

			RefreshUsersList();

			AddingOffices();
		}

		private void OfficeNumberBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			RefreshUsersList();
		}

		private void UserNameBox_GotFocus(object sender, RoutedEventArgs e)
		{
			UserNameBox.Text = UserNameBox.Text == _UserMail ? "" : UserNameBox.Text;
		}

		private void AddingOffices()
		{
			_offices = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();

			_lastIdOffice = _offices.Last().Id + 1;

			_offices.Add(new WorkingLibrary.Models.Office { Name = _AllOffices, Id = _lastIdOffice });

			OfficeNumberBox.ItemsSource = _offices;
		}

		private void RefreshUsersList()
		{
			_users = _dataWorking.GetUsers(WorkingLibrary.SqlScripts.SelectSripts.SelectUsers()).ToList();

			if (CurrentUser.user.IdUserRole != 1)
			{
				_users = _users.Where(x => x.IdUserRole != 1 && x.Id != CurrentUser.user.Id).ToList();
			}

			if (OfficeNumberBox.SelectedItem != null)
			{
				var office = (WorkingLibrary.Models.Office)OfficeNumberBox.SelectedValue;

				if (office.Id != _lastIdOffice)
				{
					_users = _users.Where(g => g.IdOffice == office.Id).ToList();
				}
			}

			if (UserNameBox.Text != "" && UserNameBox.Text != _UserMail)
			{
				_users = _users.Where(g => g.Mail.ToLower().Contains(_mail.ToLower())).ToList();
			}

			UsersGrid.ItemsSource = _users.ToList();
		}

		private void UserNameBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (UserNameBox.Text == _UserMail)
			{
				return;
			}

			_mail = UserNameBox.Text;

			RefreshUsersList();
		}

		private void UserNameBox_LostFocus(object sender, RoutedEventArgs e)
		{
			UserNameBox.Text = UserNameBox.Text == String.Empty ? _UserMail : UserNameBox.Text;
		}

		private void EditColumn_Click(object sender, RoutedEventArgs e)
		{
			if (editUser == null)
			{
				editUser = new Windows.EditUser(sender);
				editUser.usersPage = this;
				editUser.Show();
			}
		}

		private void AddUser_Click(object sender, RoutedEventArgs e)
		{
			if (addUser == null)
			{
				addUser = new Windows.AddUser();
				addUser.usersPage = this;
				addUser.Show();
			}
		}

		private void AddUserWithCode_Click(object sender, RoutedEventArgs e)
		{
			if (addUserWithInventation == null)
			{
				addUserWithInventation = new Windows.AddUserWithInventation();
				addUserWithInventation.users = this;
				addUserWithInventation.Show();
			}
		}
	}
}
