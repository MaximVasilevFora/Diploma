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
	public partial class Services : Page
	{
		private const string _ServiceName = "Наименование услуги";

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();
		private List<WorkingLibrary.Models.Service> _services;

		public Windows.AddService addService;
		public Windows.EditService editService;

		private string _findedServiceName;

		public Services()
		{
			InitializeComponent();

			InitWindow();
		}

		public void InitWindow()
		{
			if (CurrentUser.user.IdUserRole == 3)
			{
				AddService.IsEnabled = false;
				editService.IsEnabled = false;
			}

			ServiceList.ItemsSource = _dataWorking.GetServices(WorkingLibrary.SqlScripts.SelectSripts.SelectServices());
		}

		private void ServiceName_GotFocus(object sender, RoutedEventArgs e)
		{
			ServiceName.Text = ServiceName.Text == _ServiceName ? "" : ServiceName.Text;
		}

		private void ServiceName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (ServiceName.Text == _ServiceName)
			{
				return;
			}

			_findedServiceName = ServiceName.Text;
			RefreshGoodList();
		}

		public void RefreshGoodList()
		{
			_services = _dataWorking.GetServices(WorkingLibrary.SqlScripts.SelectSripts.SelectServices());

			if (CurrentUser.user.IdUserRole != 1)
			{
				_services = _services.Where(x => x.IdOffice == CurrentUser.user.IdOffice).ToList();
			}

			if (ServiceName.Text != "" && ServiceName.Text != _ServiceName)
			{
				_services = _services.Where(g => g.Name.ToLower().Contains(_findedServiceName.ToLower())).ToList();
			}

			ServiceList.ItemsSource = _services;
		}

		private void ServiceName_LostFocus(object sender, RoutedEventArgs e)
		{
			ServiceName.Text = ServiceName.Text == String.Empty ? _ServiceName : ServiceName.Text;
		}

		private void AddService_Click(object sender, RoutedEventArgs e)
		{
			if (addService == null)
			{
				addService = new Windows.AddService();
				addService.services = this;
				addService.Show();
			}
		}

		private void ServiceCard_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (editService == null)
			{
				editService = new Windows.EditService(sender);
				editService.services = this;
				editService.Show();
			}
		}
	}
}
