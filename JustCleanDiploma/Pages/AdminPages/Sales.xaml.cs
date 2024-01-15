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
	public partial class Sales : Page
	{
		private DataWorking _dataWorking = new DataWorking();
		private List<WorkingLibrary.Models.Sale> _sale;

		public Windows.AddSale addSale;
		public Windows.EditSale editSale;

		public Sales()
		{
			InitializeComponent();

			InitPage();
		}

		public void InitPage()
		{
			_sale = _dataWorking.GetSales(WorkingLibrary.SqlScripts.SelectSripts.SelectSales()).ToList();

			if (CurrentUser.user.IdUserRole != 1)
			{
				SalesGrid.ItemsSource = _sale.Where(x => x.IdOffice == CurrentUser.user.IdOffice);
			}
			else
			{
				SalesGrid.ItemsSource = _sale;
			}
		}

		private void EditColumn_Click(object sender, RoutedEventArgs e)
		{
			if (editSale == null)
			{
				editSale = new Windows.EditSale(sender);
				editSale.sales = this;
				editSale.Show();
			}
		}

		private void AddSale_Click(object sender, RoutedEventArgs e)
		{
			if (addSale == null)
			{
				addSale = new Windows.AddSale();
				addSale.sales = this;
				addSale.Show();
			}
		}
	}
}
