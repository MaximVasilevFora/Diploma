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
using System.Threading;
using WorkingLibrary;

namespace JustCleanDiploma.Pages.AdminPages
{
	public partial class Orders : Page
	{
		private const int _NewStatus = 1;
		private const int _WorkStatus = 2;
		private const int _RefuseStatus = 3;

		private List<WorkingLibrary.Models.Deal> _orders;

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();

		public Windows.AddOrder addOrder;
		public Windows.EditOrder editOrder;

		public static Windows.AdminWindow adminWindow;
		public static Windows.ContentWindow contentWindow;

		public Orders()
		{
			InitializeComponent();

			InitWindow();
		}

		public void InitWindow()
		{
			_orders = _dataWorking.GetDeals(WorkingLibrary.SqlScripts.SelectSripts.SelectDeals());

			if (CurrentUser.user.IdUserRole != 1)
			{
				_orders = _orders.Where(x => x.IdOffice == CurrentUser.user.IdOffice).ToList();
			}

			NewOrderList.ItemsSource = _orders.Where(x => x.IdStatus == _NewStatus);
			WorkOrderList.ItemsSource = _orders.Where(x => x.IdStatus == _WorkStatus);
			RefuseOrderList.ItemsSource = _orders.Where(x => x.IdStatus == _RefuseStatus);
		}

		private void AddOrder_Click(object sender, RoutedEventArgs e)
		{
			if (addOrder == null)
			{
				addOrder = new Windows.AddOrder();
				addOrder.orders = this;
				addOrder.Show();
			}
		}

		private void UpdateOrders_Click(object sender, RoutedEventArgs e)
		{
			InitWindow();
			
			Thread.Sleep(500);
		}

		private void NewOrderCard_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (editOrder == null)
			{
				editOrder = new Windows.EditOrder(sender);
				editOrder.orders = this;
				editOrder.Show();
			}
		}

		private void ShowDeals_Click(object sender, RoutedEventArgs e)
		{
			if (adminWindow != null)
			{
				adminWindow.ChangePage("Pages/AdminPages/RefuseDeals.xaml");
			}
			else
			{
				contentWindow.ChangePage("Pages/AdminPages/RefuseDeals.xaml");
			}
		}
	}
}
