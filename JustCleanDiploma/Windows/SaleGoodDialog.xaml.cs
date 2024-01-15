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
	public partial class SaleGoodDialog : Window
	{
		public Pages.AdminPages.Goods goodPage;

		private WorkingLibrary.Models.Good _good;
		private int _goodId;

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();

		private const string _GoodQuantity = "Количество";
		private const string _GoodCost = "Стоимость";

		public SaleGoodDialog(int id)
		{
			InitializeComponent();

			_goodId = id;

			InitPage();
		}
	
		public void InitPage()
		{
			UserMail.ItemsSource = _dataWorking.GetUsers(WorkingLibrary.SqlScripts.SelectSripts.SelectUsers()).ToList();
			Office.ItemsSource = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();
		}

		private void Quantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
		}

		private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			goodPage.saleGoodDialog = null;
			goodPage.RefreshGoodList();
		}

		private void Enter_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(Quantity.Text) || Quantity.Text == _GoodQuantity)
			{
				MessageBox.Show("Введите значение в поле Количество товара");
				return;
			}

			if (Convert.ToInt32(Quantity.Text) < 1)
			{
				MessageBox.Show("Введите значение в поле Количество больше чем Ноль");
				return;
			}

			if (string.IsNullOrEmpty(Price.Text) || Price.Text == _GoodCost)
			{
				MessageBox.Show("Введите значение в поле Общая стоимость товаров");
				return;
			}

			if (SaleDate.SelectedDate == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Дата продажи");
				return;
			}

			if (Office.SelectedItem == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Офис");
				return;
			}

			int? userId = null;

			if (UserMail.SelectedItem != null)
			{
				WorkingLibrary.Models.User user = (WorkingLibrary.Models.User)UserMail.SelectedValue;
				userId = user.Id;
			}

			WorkingLibrary.Models.Office office = (WorkingLibrary.Models.Office)Office.SelectedValue;

			var responce = WorkingLibrary.SqlScripts.InsertScripts.InsertSale(Convert.ToInt32(Quantity.Text), 
				Convert.ToInt32(Price.Text), 
				Description.Text, 
				SaleDate.SelectedDate.Value, 
				_goodId,
				userId,
				office.Id);

			if (responce)
			{
				MessageBox.Show("Продажа товара была успешно зафиксирована");

				WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[5], CurrentUser.user.Id, CurrentUser.user.IdOffice);
			}

			this.Close();
		}

		private void Quantity_GotFocus(object sender, RoutedEventArgs e)
		{
			Quantity.Text = Quantity.Text == _GoodQuantity ? "" : Quantity.Text;
		}

		private void Quantity_LostFocus(object sender, RoutedEventArgs e)
		{
			Quantity.Text = Quantity.Text == String.Empty ? _GoodQuantity : Quantity.Text;
		}

		private void Price_GotFocus(object sender, RoutedEventArgs e)
		{
			Price.Text = Price.Text == _GoodCost ? "" : Price.Text;
		}

		private void Price_LostFocus(object sender, RoutedEventArgs e)
		{
			Price.Text = Quantity.Text == String.Empty ? _GoodCost : Price.Text;
		}
	}
}
