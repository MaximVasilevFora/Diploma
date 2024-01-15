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
	public partial class AddUserWithInventation : Window
	{
		private const string _Code = "Пригласительный код";

		public Pages.AdminPages.Users users;

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();

		public AddUserWithInventation()
		{
			InitializeComponent();

			Role.ItemsSource = _dataWorking.GetUserRoles(WorkingLibrary.SqlScripts.SelectSripts.SelectUserRoles()).Where(x => x.Id != 1).ToList();
		}

		private bool SimbolIsDigit(TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				return true;
			}

			return false;
		}

		private void InviteCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = SimbolIsDigit(e);
		}

		private void InviteCode_LostFocus(object sender, RoutedEventArgs e)
		{
			InviteCode.Text = InviteCode.Text == String.Empty ? _Code : InviteCode.Text;
		}

		private void InviteCode_GotFocus(object sender, RoutedEventArgs e)
		{
			InviteCode.Text = InviteCode.Text == _Code ? "" : InviteCode.Text;
		}

		private void AddUser_Click(object sender, RoutedEventArgs e)
		{
			if (InviteCode.Text == _Code)
			{
				MessageBox.Show("Введите значение в поле Пригласительный код");
				return;
			}

			if (InviteCode.Text.Length < 6)
			{
				MessageBox.Show("Пригласительный код состоит из 6 символов");
				return;
			}

			if (!WorkingLibrary.SqlScripts.SelectSripts.CheckInviteCode(InviteCode.Text))
			{
				MessageBox.Show("Пользоваетля с таким пригласительным кодом не существует");
				return;
			}

			if (Role.SelectedItem == null)
			{
				MessageBox.Show("Выберите значение в поле Должность");
				return;
			}

			WorkingLibrary.Models.UserRole role = (WorkingLibrary.Models.UserRole)Role.SelectedValue;

			if (WorkingLibrary.SqlScripts.UpdateScripts.UpdateUserWithCode(role.Id, Convert.ToInt32(WorkingLibrary.CurrentUser.user.IdOffice), Convert.ToInt32(InviteCode.Text)))
			{
				MessageBox.Show("Пользователь был успешно прикреплен к офису");

				WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[8], CurrentUser.user.Id, CurrentUser.user.IdOffice);

				this.Close();
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			users.addUserWithInventation = null;
		}
	}
}
