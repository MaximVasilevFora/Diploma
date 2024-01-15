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
	public partial class Goods : Page
	{
		private const string _GoodName = "Наименование товара";
		private int _goodId;

		private string _findedGoodName;

		public Windows.AddGood addGood;
		public Windows.EditGood editGood;
		public Windows.SaleGoodDialog saleGoodDialog;

		private List<WorkingLibrary.Models.Good> _listOfGood;

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();

		public Goods()
		{
			InitializeComponent();

			InitWindow();
		}

		private void InitWindow()
		{
			if (CurrentUser.user.IdUserRole == 3)
			{
				AddGood.IsEnabled = false;
			}

			RefreshGoodList();
		}

		private void GoodNameBox_GotFocus(object sender, RoutedEventArgs e)
		{
			GoodNameBox.Text = GoodNameBox.Text == _GoodName ? "" : GoodNameBox.Text;
		}

		private void GoodNameBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (GoodNameBox.Text == _GoodName)
			{
				return;
			}

			_findedGoodName = GoodNameBox.Text;

			RefreshGoodList();
		}

		private void GoodNameBox_LostFocus(object sender, RoutedEventArgs e)
		{
			GoodNameBox.Text = GoodNameBox.Text == String.Empty ? _GoodName : GoodNameBox.Text;
		}

		public void RefreshGoodList()
		{
			_listOfGood = _dataWorking.GetGoods(WorkingLibrary.SqlScripts.SelectSripts.SelectGoods());

			if (CurrentUser.user.IdUserRole != 1)
			{
				_listOfGood = _listOfGood.Where(x => x.IdOffice == CurrentUser.user.IdOffice).ToList();
			}

			if (GoodNameBox.Text != "" && GoodNameBox.Text != _GoodName)
			{
				_listOfGood = _listOfGood.Where(g => g.Name.ToLower().Contains(_findedGoodName.ToLower())).ToList();
			}

			GoodsList.ItemsSource = _listOfGood;
		}

		private void AddGood_Click(object sender, RoutedEventArgs e)
		{
			if (addGood == null)
			{
				addGood = new Windows.AddGood();
				addGood.goodsPage = this;
				addGood.Show();
			}
		}

		private void EditGood_Click(object sender, RoutedEventArgs e)
		{
			if (editGood != null)
			{
				editGood.Close();
			}

			if (saleGoodDialog == null)
			{
				saleGoodDialog = new Windows.SaleGoodDialog(_goodId);
				saleGoodDialog.goodPage = this;
				saleGoodDialog.Show();
			}
		}

		private void CardGood_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			_goodId = ((sender as Grid).DataContext as WorkingLibrary.Models.Good).Id;

			if (editGood == null && saleGoodDialog == null && CurrentUser.user.IdUserRole != 3)
			{
				editGood = new Windows.EditGood(sender);
				editGood.goodsPage = this;
				editGood.Show();
			}
		}
	}
}
