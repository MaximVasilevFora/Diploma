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
	public partial class Clients : Page
	{
		private List<WorkingLibrary.Models.Client> _clients;
		private List<WorkingLibrary.Models.Office> _offices;
		private DataWorking _dataWorking = new DataWorking();

		public Windows.EditClient editClient;
		public Windows.AddClient addClient;

		private const string _ClientPhone = "Номер телефона";
		private const string _AllOffices = "Все офисы";

		private int _lastIdOffice;
		private string _phone;

		public Clients()
		{
			InitializeComponent();

			InitPage();
		}

		public void InitPage()
		{
			if (CurrentUser.user.IdUserRole != 1)
			{
				OfficeNumberBox.Visibility = Visibility.Collapsed;

				if (CurrentUser.user.IdUserRole == 3)
				{
					AddClient.IsEnabled = false;
					editClient.IsEnabled = false;
				}
			}
			else
			{
				AddingOffices();
				ClientsGrid.Height = 375;
			}

			RefreshUsersList();
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
			_clients = _dataWorking.GetClients(WorkingLibrary.SqlScripts.SelectSripts.SelectClients()).ToList();

			if (CurrentUser.user.IdUserRole != 1)
			{
				_clients = _clients.Where(x => x.IdOffice == CurrentUser.user.IdOffice).ToList();
			}

			if (OfficeNumberBox.SelectedItem != null)
			{
				var office = (WorkingLibrary.Models.Office)OfficeNumberBox.SelectedValue;

				if (office.Id != _lastIdOffice)
				{
					_clients = _clients.Where(g => g.IdOffice == office.Id).ToList();
				}
			}

			if (ClientPhoneBox.Text != "" && ClientPhoneBox.Text != _ClientPhone)
			{
				_clients = _clients.Where(g => g.Phone.ToLower().Contains(_phone.ToLower())).ToList();
			}

			ClientsGrid.ItemsSource = _clients.ToList();
		}

		private void ClientPhoneBox_GotFocus(object sender, RoutedEventArgs e)
		{
			ClientPhoneBox.Text = ClientPhoneBox.Text == _ClientPhone ? "" : ClientPhoneBox.Text;
		}

		private void ClientPhoneBox_LostFocus(object sender, RoutedEventArgs e)
		{
			ClientPhoneBox.Text = ClientPhoneBox.Text == String.Empty ? _ClientPhone : ClientPhoneBox.Text;
		}

		private void EditColumn_Click(object sender, RoutedEventArgs e)
		{
			if (editClient == null)
			{
				editClient = new Windows.EditClient(sender);
				editClient.clientsPage = this;
				editClient.Show();
			}
		}

		private void AddClient_Click(object sender, RoutedEventArgs e)
		{
			if (addClient == null)
			{
				addClient = new Windows.AddClient();
				addClient.clientsPage = this;
				addClient.Show();
			}
		}

		private void ClientPhoneBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (ClientPhoneBox.Text == _ClientPhone)
			{
				return;
			}

			_phone = ClientPhoneBox.Text;

			RefreshUsersList();
		}

		private void OfficeNumberBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			RefreshUsersList();
		}
	}
}
