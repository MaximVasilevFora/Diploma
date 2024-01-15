using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
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
	public partial class AddGood : Window
	{
		private const string _Description = "Описание";
		private const string _GoodName = "Наименование";
		private const string _PurchasePrice = "Цена закупочная";
		private const string _SalePrice = "Цена розничная";
		private const string _FilePath = "Не выбран";

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();
		private List<WorkingLibrary.Models.Office> _office;
		private List<WorkingLibrary.Models.Provider> _provider;

		private byte[] _goodImageOfByte = null;

		private System.Windows.Forms.OpenFileDialog _openFileDialog = new System.Windows.Forms.OpenFileDialog();

		public Pages.AdminPages.Goods goodsPage;

		public AddGood()
		{
			InitializeComponent();

			_openFileDialog.Filter = "Png files(*.png)|*.png|Jpg files(*.jpg)|*.jpg|Jpeg files(*.jpeg)|*.jpeg";

			_office = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();
			_provider = _dataWorking.GetProviders(WorkingLibrary.SqlScripts.SelectSripts.SelectProviders()).ToList();

			InitWindow();
		}

		private void InitWindow()
		{
			Office.ItemsSource = _office;
			Provider.ItemsSource = _provider;

			if (CurrentUser.user.IdUserRole != 1)
			{
				Office.SelectedItem = _office.Where(x => x.Id == CurrentUser.user.IdOffice).Last();
				Office.IsEnabled = false;
			}
			else
			{
				Office.SelectedIndex = -1;
			}
			
			Provider.SelectedIndex = -1;
			GoodName.Text = _GoodName;
			PurchasePrice.Text = _PurchasePrice;
			SalePrice.Text = _SalePrice;
			Description.Text = _Description;

			EmptyImage();
		}

		private void CancelImage_Click(object sender, RoutedEventArgs e)
		{
			EmptyImage();
		}

		private void EmptyImage()
		{
			_goodImageOfByte = null;
			FilePath.Text = _FilePath;
		}

		private void GetImage_Click(object sender, RoutedEventArgs e)
		{
			if (_openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				var image = new Bitmap(_openFileDialog.FileName);

				FilePath.Text = _openFileDialog.FileName;

				_goodImageOfByte = _dataWorking.ImageToByte(image);
			}
		}

		private bool SimbolIsDigit(TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				return true;
			}

			return false;
		}

		private void PurchasePrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = SimbolIsDigit(e);
		}

		private void SalePrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = SimbolIsDigit(e);
		}

		private void GoodName_GotFocus(object sender, RoutedEventArgs e)
		{
			GoodName.Text = GoodName.Text == _GoodName ? "" : GoodName.Text;
		}

		private void GoodName_LostFocus(object sender, RoutedEventArgs e)
		{
			GoodName.Text = GoodName.Text == String.Empty ? _GoodName : GoodName.Text;
		}

		private void PurchasePrice_GotFocus(object sender, RoutedEventArgs e)
		{
			PurchasePrice.Text = PurchasePrice.Text == _PurchasePrice ? "" : PurchasePrice.Text;
		}

		private void PurchasePrice_LostFocus(object sender, RoutedEventArgs e)
		{
			PurchasePrice.Text = PurchasePrice.Text == String.Empty ? _PurchasePrice : PurchasePrice.Text;
		}

		private void SalePrice_GotFocus(object sender, RoutedEventArgs e)
		{
			SalePrice.Text = SalePrice.Text == _SalePrice ? "" : SalePrice.Text;
		}

		private void SalePrice_LostFocus(object sender, RoutedEventArgs e)
		{
			SalePrice.Text = SalePrice.Text == String.Empty ? _SalePrice : SalePrice.Text;
		}

		private void Description_GotFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == _Description ? "" : Description.Text;
		}

		private void Description_LostFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == String.Empty ? _Description : Description.Text;
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			if (Office.SelectedItem == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Офис");
				return;
			}

			if (GoodName.Text == _GoodName)
			{
				System.Windows.MessageBox.Show("Введите Наименование товара");
				return;
			}

			if (PurchasePrice.Text == _PurchasePrice)
			{
				System.Windows.MessageBox.Show("Введите Закупочную цену");
				return;
			}

			if (SalePrice.Text == _SalePrice)
			{
				System.Windows.MessageBox.Show("Введите Розничную цену");
				return;
			}

			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("INSERT INTO `good` " +
				"(`name`, `purchase_price`, `sale_price`, `image`, `description`, `id_provider`, `id_office`) " +
				"VALUES (@name, @purchase_price, @sale_price, @image, @description, @id_provider, @id_office)", dataBase.GetConnection());
			
			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = GoodName.Text;
			mySqlCommand.Parameters.Add("@purchase_price", MySqlDbType.Int32).Value = Convert.ToInt32(PurchasePrice.Text);
			mySqlCommand.Parameters.Add("@sale_price", MySqlDbType.Int32).Value = Convert.ToInt32(SalePrice.Text);
			mySqlCommand.Parameters.Add("@image", MySqlDbType.MediumBlob).Value = _goodImageOfByte == null ? null : _goodImageOfByte;
			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = Description.Text == _Description ? null : Description.Text;

			WorkingLibrary.Models.Office office = (WorkingLibrary.Models.Office)Office.SelectedValue;

			if (Provider.SelectedItem == null)
			{
				mySqlCommand.Parameters.Add("@id_provider", MySqlDbType.Int32).Value = null;
			}
			else
			{
				WorkingLibrary.Models.Provider provider = (WorkingLibrary.Models.Provider)Provider.SelectedValue;
				mySqlCommand.Parameters.Add("@id_provider", MySqlDbType.Int32).Value = provider.Id;
			}

			mySqlCommand.Parameters.Add("@id_office", MySqlDbType.Int32).Value = office.Id;

			dataBase.OpenConnection();

			try
			{
				if (mySqlCommand.ExecuteNonQuery() == 1)
				{
					System.Windows.MessageBox.Show("Товар был добавлен");
				}
				else
				{
					System.Windows.MessageBox.Show("Ошибка добавления товара");
					return;
				}
			}
			catch
			{
				MessageBox.Show("Изображение товара с данным форматом имеет слишком большой вес, выберите другое изображние.");
				dataBase.CloseConnection();
				return;
			}

			dataBase.CloseConnection();

			WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[2], CurrentUser.user.Id, CurrentUser.user.IdOffice);

			goodsPage.RefreshGoodList();

			this.Close();
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			var result = System.Windows.MessageBox.Show("Вы уверены, что хотите отменить изменения?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.No)
			{
				return;
			}

			InitWindow();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			goodsPage.addGood = null;
		}
	}
}
