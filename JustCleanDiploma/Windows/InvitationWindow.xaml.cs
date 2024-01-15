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
	public partial class InvitationWindow : Window
	{
		private int _invitationCode;

		public Windows.EditUser editUser;

		private DataWorking _dataWorking = new DataWorking();
		private AuthorizationWindow _authorizationWindow;

		public InvitationWindow()
		{
			InitializeComponent();

			InitWindow();
		}

		public void InitWindow()
		{
			Mail.Text = CurrentUser.user.Mail;

			if (CurrentUser.user.Image != null)
			{
				Profil.ImageSource = _dataWorking.GetBitmapImage(CurrentUser.user.Image);
			}

			_invitationCode = CurrentUser.user.InvitationCode;

			CodeBlock.Text = Convert.ToString(_invitationCode);
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			if (_authorizationWindow == null)
			{ 
				_authorizationWindow = new AuthorizationWindow();
				_authorizationWindow.Show();
				this.Close();
			}
		}

		private void Profil_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{

		}

		private void ProfilePanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (editUser == null)
			{
				editUser = new EditUser(CurrentUser.user);
				editUser.Role.IsEnabled = false;
				editUser.Office.IsEnabled = false;
				editUser.invitationWindow = this;
				editUser.Show();
			}
		}
	}
}
