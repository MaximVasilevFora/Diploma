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
	public partial class Providers : Page
	{
		private DataWorking _dataWorking = new DataWorking();
		private List<WorkingLibrary.Models.Provider> _providers;

		public Windows.AddProvider addProvider;
		public Windows.EditProvider editProvider;

		public Providers()
		{
			InitializeComponent();

			InitPage();
		}

		public void InitPage()
		{
			if (CurrentUser.user.IdUserRole == 3)
			{
				AddProvider.IsEnabled = false;
				editProvider.IsEnabled = false;
			}

			_providers = _dataWorking.GetProviders(WorkingLibrary.SqlScripts.SelectSripts.SelectProviders()).ToList();
			ProvidersGrid.ItemsSource = _providers;
		}

		private void AddProvider_Click(object sender, RoutedEventArgs e)
		{
			if (addProvider == null)
			{
				addProvider = new Windows.AddProvider();
				addProvider.providers = this;
				addProvider.Show();
			}
		}

		private void EditColumn_Click(object sender, RoutedEventArgs e)
		{
			if (editProvider == null)
			{
				editProvider = new Windows.EditProvider(sender);
				editProvider.providers = this;
				editProvider.Show();
			}
		}
	}
}
