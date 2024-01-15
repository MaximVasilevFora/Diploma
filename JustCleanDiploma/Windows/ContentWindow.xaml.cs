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
using System.Windows.Threading;
using WorkingLibrary;

namespace JustCleanDiploma.Windows
{
	public partial class ContentWindow : Window
	{
		private DataWorking _dataWorking = new DataWorking();
		private DispatcherTimer _timer;

		private double _panelWidth;
		private bool _hidden;

		public EditUser editUser;

		public ContentWindow()
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

			ChangePage("Pages/AdminPages/WelcomePage.xaml");

			_timer = new DispatcherTimer();
			_timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
			_timer.Tick += Timer_Tick;

			_panelWidth = sidePanel.MaxWidth;
		}

		public void ChangePage(string url)
		{
			ContentFrame.NavigationService.Navigate(new Uri(url, UriKind.Relative));
			Pages.AdminPages.Orders.contentWindow = this;
			Pages.AdminPages.WelcomePage.contentWindow = this;
			Pages.AdminPages.RefuseDeals.contentWindow = this;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (_hidden)
			{
				sidePanel.MaxWidth += 2;

				if (sidePanel.MaxWidth >= _panelWidth)
				{
					_timer.Stop();
					_hidden = false;
				}
			}
			else
			{
				sidePanel.MaxWidth -= 2;

				if (sidePanel.MaxWidth <= 35)
				{
					_timer.Stop();
					_hidden = true;
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			_timer.Start();
		}

		private void PanelHeader_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}

		private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ChangePage("Pages/AdminPages/Users.xaml");
		}

		private void OfficesView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ChangePage("Pages/AdminPages/Offices.xaml");
		}

		private void ClientsView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ChangePage("Pages/AdminPages/Clients.xaml");
		}

		private void OrderView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ChangePage("Pages/AdminPages/Orders.xaml");

		}

		private void SalesView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ChangePage("Pages/AdminPages/Sales.xaml");
		}

		private void GoodsView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ChangePage("Pages/AdminPages/Goods.xaml");
		}

		private void ServicesView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ChangePage("Pages/AdminPages/Services.xaml");
		}

		private void ProvidersView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ChangePage("Pages/AdminPages/Providers.xaml");
		}

		private void ProfilePanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (editUser == null)
			{
				editUser = new EditUser(CurrentUser.user);
				editUser.Role.IsEnabled = false;
				editUser.Office.IsEnabled = false;
				editUser.contentWindow = this;
				editUser.Show();
			}
		}

		private void Audit_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ChangePage("Pages/AdminPages/Audit.xaml");
		}

		private void Money_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ChangePage("Pages/AdminPages/Money.xaml");
		}
	}
}
