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
	public partial class Offices : Page
	{
		private DataWorking _dataWorking = new DataWorking();
		private List<WorkingLibrary.Models.Office> _offices;

		public Windows.AddOffice addOffice;
		public Windows.EditOffice editOffice;

		public Offices()
		{
			InitializeComponent();

			InitPage();
		}

		public void InitPage()
		{
			_offices = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();
			OfficesGrid.ItemsSource = _offices;
		}

		private void EditColumn_Click(object sender, RoutedEventArgs e)
		{
			if (editOffice == null)
			{
				editOffice = new Windows.EditOffice(sender);
				editOffice.Offices = this;
				editOffice.Show();
			}
		}

		private void AddOffice_Click(object sender, RoutedEventArgs e)
		{
			if (addOffice == null)
			{
				addOffice = new Windows.AddOffice();
				addOffice.Offices = this;
				addOffice.Show();
			}
		}
	}
}
