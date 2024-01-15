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

namespace JustCleanDiploma.Pages.AdminPages
{
	public partial class RefuseDeals : Page
	{
		public static Windows.AdminWindow adminWindow;
		public static Windows.ContentWindow contentWindow;

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();
		private WorkingLibrary.Models.Deal _deal;
		private const int _NewStatus = 1;
		private const int _EnterStatus = 4;

		public RefuseDeals()
		{
			InitializeComponent();

			DealsGrid.ItemsSource = _dataWorking.GetDeals(WorkingLibrary.SqlScripts.SelectSripts.SelectDeals()).Where(x => x.IdStatus == _EnterStatus);
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			var result = System.Windows.MessageBox.Show("Вы уверены, что хотите вернуть заявку?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.No)
			{
				return;
			}

			_deal = (sender as Button).DataContext as WorkingLibrary.Models.Deal;

			if (WorkingLibrary.SqlScripts.UpdateScripts.UpdateDealStatus(_deal.Id, _NewStatus))
			{
				MessageBox.Show("Заявке с именем: " + _deal.Name + " был успешно присвоен статус `Новый`");

				if (adminWindow != null)
				{
					adminWindow.ChangePage("Pages/AdminPages/Orders.xaml");
				}
				else
				{
					contentWindow.ChangePage("Pages/AdminPages/Orders.xaml");
				}
			}
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			if (adminWindow != null)
			{
				adminWindow.ChangePage("Pages/AdminPages/Orders.xaml");
			}
			else
			{
				contentWindow.ChangePage("Pages/AdminPages/Orders.xaml");
			}
		}
	}
}
